using UnityEngine;

public struct ItemSlot
{
    public InventoryItem item;
    [Min(1)] public int itemQuantity;

    //operator keyword is used to define custom action on the == operator.
    public static bool operator == (ItemSlot a, ItemSlot b)
    {
        return a.Equals(b);
    }
    public static bool operator != (ItemSlot a, ItemSlot b)
    {
        return !a.Equals(b);
    }

    public ItemSlot(InventoryItem item, int quantity)
    {
        this.item = item;
        this.itemQuantity = quantity;
    }
}
