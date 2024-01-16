using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Equipment,
    Default
}
public abstract class ItemObj : ScriptableObject
{
    public int Id;
    public Sprite uiDisplay;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
}

[System.Serializable]
public class Item
{
    public string name;
    public int Id;
    public Item(ItemObj item)
    {
        name = item.name;
        Id = item.Id;
    }
}




