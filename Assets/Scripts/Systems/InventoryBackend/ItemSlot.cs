using System;
using UnityEngine;

//second script

[Serializable]
public struct ItemSlot
{
    public InventoryItem item;
    public int quantity;

    //Contructor is optional. This system is built to need one
    public ItemSlot(InventoryItem item, int quantity)
    {
       this.item = item;
       this.quantity = quantity;
    }
}