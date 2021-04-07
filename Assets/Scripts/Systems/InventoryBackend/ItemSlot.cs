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

    //operator keyword is used to define custom action on the == operator.
    public static bool operator ==(ItemSlot a, ItemSlot b) { return a.Equals(b); }
    public static bool operator !=(ItemSlot a, ItemSlot b) { return !a.Equals(b); }
}