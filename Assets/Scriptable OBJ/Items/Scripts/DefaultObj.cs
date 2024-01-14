using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Deafult Object", menuName ="Inventory System/Items/Default")]
public class DefaultObj : ItemObj
{
    public void Awake()
    {
        type = ItemType.Default;
    }
}
