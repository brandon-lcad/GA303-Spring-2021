using System.Text;
using UnityEngine;

//Data constructors built 4th
[CreateAssetMenu(fileName = "new Craftable", menuName = "Database/Crafted Items")]
public class CraftablesData : InventoryItem
{
    public void Awake()
    {
        itemType = ItemType.Craftable;
    }

    [Header("Crafted Item Data")]
    [SerializeField] private string useText = "GULP.";

    //public override string NameTint => throw new System.NotImplementedException();

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
