using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable]
public struct RecipeInputList
{
    public MaterialsData recipeInput;
    public int amount;
}

[CreateAssetMenu(fileName = "New Recipe", menuName = "Database/Recipes")]
public class RecipeData : InventoryItem
{
    [Header("Crafted Item Data")]
    public List<RecipeInputList> materials;
    public CraftablesData recipeOutput;
    [SerializeField] private bool isStackable;
    [SerializeField] private string useText = "LEARNINS";

    public void Awake()
    {
        itemType = ItemType.Recipe;
    }

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
