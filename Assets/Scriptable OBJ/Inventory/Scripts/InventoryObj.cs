using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObj : ScriptableObject, ISerializationCallbackReceiver
{
    public string savePath;
    private ItemDataBase dataBase;
    public List<InventorySlot> Container = new List<InventorySlot>();

    private void OnEnable()
    {
#if UNITY_EDITOR
        dataBase = (ItemDataBase)AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset", typeof(ItemDataBase));
#else
        dataBase = Resources.Load<ItemDataBase>("Database");
#endif
    }
    public void AddItem(ItemObj _item, int _amount)
    {

        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);

                return;
            }
        }
        Container.Add(new InventorySlot(dataBase.GetID[_item], _item, _amount));
    }

    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();

    }

    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter(); 
            FileStream file = File.Open(string.Concat(Application.persistentDataPath,savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(),this);
            file.Close();
        }
    }


    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Container.Count; i++)

            Container[i].item = dataBase.GetItem[Container[i].ID];
        
    }

    public void OnBeforeSerialize()
    {
        
    }
}

[System.Serializable]
public class InventorySlot
{
    public int ID;
    public ItemObj item;
    public int amount;
    public InventorySlot(int _id, ItemObj _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}