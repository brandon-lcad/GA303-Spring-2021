using UnityEngine;

//third script
public abstract class InventoryItem : GameData
{
    [Header("Item Data")]
    [SerializeField][Min(0)] private int buyPrice = 0;
    [SerializeField][Min(0)] private int sellPrice = 0;
    [SerializeField][Min(1)] private int maxStack = 0;


    public int BuyPrice => buyPrice;
    public int SellPrice => sellPrice;
    public int MaxStack => maxStack;
    //public ItemQuality ItemQuality => ItemQuality;


    //public int BuyPrice { get { return buyPrice; } }
    //public int SellPrice { get { return sellPrice; } }
    //public int MaxStack { get { return maxStack; } }
}
