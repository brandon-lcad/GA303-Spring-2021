using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Craftable", menuName = "Item System/Database/Crafted Items")]
public class CraftablesData : GameItem
{
    public void Awake()
    {
        itemType = ItemType.Craftable;
    }

    public bool isStackable;
    public int stackableQty;

    /*private int AssignID()
    {
        if(itemId = 0)
        {
            itemId = Random.Range(1001, 9999);
        }
        return itemId;
    }*/
}