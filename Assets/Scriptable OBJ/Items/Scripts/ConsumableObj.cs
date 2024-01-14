using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Object", menuName = "Inventory System/Items/Consumable")]
public class ConsumableObj : ItemObj
{
    public int restoreHealthValue;
    public void Awake()
    {
        type = ItemType.Consumable;
    }
}
