using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObj : ScriptableObject
{
    public ItemDataBase dataBase;
    public List<InventorySlot> Container = new List<InventorySlot>();
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