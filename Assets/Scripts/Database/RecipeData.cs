using System.Collections.Generic;
using System.Text;
using UnityEngine;

[SerializeField]
public struct RecipeInputList
{
    public MaterialsData inputItem;
    public int inputAmount;
}

[CreateAssetMenu(fileName = "New Recipe", menuName = "Database/Recipes")]
public abstract class RecipeData : InventoryItem
{
    public void Awake()
    {
        itemType = ItemType.Recipe;
    }

    [Header("Crafted Item Data")]
    [SerializeField] private bool isStackable;
    [SerializeField] private string useText = "LEARNINS";
    public List<RecipeInputList> recipeInput;
    public MaterialsData recipeOutput;

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
