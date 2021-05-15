using System.Text;
using UnityEngine;


[CreateAssetMenu(fileName = "new Material", menuName = "Database/Materials")]
public class MaterialsData : InventoryItem
{
    public void Awake()
    {
        itemType = ItemType.Material;
    }

    [Header("Crafted Item Data")]
    [SerializeField] private string useText = "NIBBLE";




    public override string GetInfoDisplayText()
    {
        //CUsing builder because it's more performant. 
        //It returns ALL info as a string VS concatination which spits out 
        //1x per section.
        StringBuilder builder = new StringBuilder();
        builder.Append(useText).AppendLine();
        builder.Append("Max Stack: ").Append(MaxStack).AppendLine();
        builder.Append("Sell Price: ").Append(SellPrice).Append(" Gold");

        return builder.ToString();
    }
}
