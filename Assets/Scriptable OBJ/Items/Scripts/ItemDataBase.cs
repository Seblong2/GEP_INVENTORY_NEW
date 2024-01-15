using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item DataBase", menuName = "Inventory System/Items/Database")]
public class ItemDataBase : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObj[] Items;
    public Dictionary<ItemObj ,int> GetID = new Dictionary<ItemObj, int>() ;
    public Dictionary<int, ItemObj> GetItem = new Dictionary<int, ItemObj>();

    public void OnAfterDeserialize()
    {
        GetID = new Dictionary<ItemObj, int>();
        GetItem = new Dictionary<int, ItemObj>();
        for (int i = 0; i < Items.Length; i++)
        {
            GetID.Add(Items[i], i);
            GetItem.Add(i, Items[i]);

        }
    }

    public void OnBeforeSerialize()
    {
        
    }
}
