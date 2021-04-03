using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum ItemQuality
{
    Junk,
    Common,
    Uncommon,
    Rare,
    Null
}

[CreateAssetMenu(fileName = "new Material", menuName = "Database/Materials")]
public class MaterialsData : InventoryItem
{
    public void Awake()
    {
        itemType = ItemType.Material;
    }

    [Header("Crafted Item Data")]
    [SerializeField] private bool isStackable;
    [SerializeField] private string useText = "NIBBLE";
    public ItemQuality itemQuality;

    public override string GetInfoDisplayText()
    {
        //CUsing builder because it's more performant. 
        //It returns ALL info as a string VS concatination which spits out 
        //1x per section.
        StringBuilder builder = new StringBuilder();
        builder.Append(ItemName).AppendLine();
        builder.Append("<color=white> Use:").Append(useText).Append("</color>").AppendLine();
        builder.Append("Max Stack: ").Append(MaxStack).AppendLine();
        builder.Append("Sell Price: ").Append(SellPrice).Append(" Gold");

        return builder.ToString();
    }
}
