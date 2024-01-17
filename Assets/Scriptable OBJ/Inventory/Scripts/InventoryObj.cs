using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObj : ScriptableObject
{
    public string savePath;
    public ItemDataBase dataBase;
    public Inventory Container;



    public void AddItem(Item _item, int _amount)
    {

        if (_item.buffs.Length > 0)
        {
            SetEmptySlot(_item, _amount);
            return;
        }

        for (int i = 0; i < Container.Items.Length; i++)
        {
            if (Container.Items[i].ID == _item.Id)
            {
                Container.Items[i].AddAmount(_amount);

                return;
            }
        }
        SetEmptySlot(_item, _amount);
    }
    public InventorySlot SetEmptySlot(Item _item, int _amount)
    {
        for (int i = 0;i < Container.Items.Length;i++)
        {
            if (Container.Items[i].ID <= -1)
            {
                Container.Items[i].UpdateSlot(_item.Id, _item, _amount);
                return Container.Items[i];
            }
        }
        return null;
    }
    [ContextMenu("Save")]
    public void Save()
    {
        //EDITABLE BY PLAYER SAVE FILE

        /*  string saveData = JsonUtility.ToJson(this, true);
          BinaryFormatter bf = new BinaryFormatter();
          FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
          bf.Serialize(file, saveData);
          file.Close();
  */

        //NON - EDITABLE BY PLAYER SAVE FILE
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, Container);
        stream.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            //EDITABLE BY PLAYER LOAD FILE

            /*BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();*/

            //NON - EDITABLE BY PLAYER LOAD FILE
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Container = (Inventory)formatter.Deserialize(stream);
            stream.Close();
        }
    }
    [ContextMenu("Clear")]
    public void clear()
    {
        Container = new Inventory();
    }
}



[System.Serializable]
public class Inventory
{
    public InventorySlot[] Items = new InventorySlot[24];
}




[System.Serializable]
public class InventorySlot
{
    public int ID = -1;
    public Item item;
    public int amount;
    public InventorySlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public void UpdateSlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public InventorySlot()
    {
        ID = -1;
        item = null;
        amount = 0;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}