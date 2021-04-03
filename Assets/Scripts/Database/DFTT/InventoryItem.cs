using UnityEngine;

public abstract class InventoryItem : GameData
{
    [Header("Recipe Data")]
    [Min(0)] readonly private int buyPrice;
    [Min(0)] readonly private int sellPrice;
    [Min(1)] readonly private int maxStack;

    public int BuyPrice => buyPrice;
    public int SellPrice => sellPrice;
    public int MaxStack => maxStack;

    public override string NameTint
    {
        get { return ItemName; }
    }
    //public int BuyPrice { get { return buyPrice; } }
    //public int SellPrice { get { return sellPrice; } }
    //public int MaxStack { get { return maxStack; } }
}
