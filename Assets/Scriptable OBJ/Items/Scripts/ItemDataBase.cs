using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item DataBase", menuName = "Inventory System/Items/Database")]
public class ItemDataBase : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObj[] Items;
    
    public Dictionary<int, ItemObj> GetItem = new Dictionary<int, ItemObj>();

    public void OnAfterDeserialize()
    {
        
        
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].Id = i;
            GetItem.Add(i, Items[i]);

        }
    }

    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, ItemObj>();
    }
}
