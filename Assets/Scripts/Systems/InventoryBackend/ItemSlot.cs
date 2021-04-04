using UnityEngine;
using System;

[Serializable]
public struct ItemSlot
{
    public InventoryItem item;
    public int quantity;


    public ItemSlot(InventoryItem item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }

    //operator keyword is used to define custom action on the == operator.
    public static bool operator == (ItemSlot a, ItemSlot b) { return a.Equals(b); }
    public static bool operator != (ItemSlot a, ItemSlot b) { return !a.Equals(b); }
}