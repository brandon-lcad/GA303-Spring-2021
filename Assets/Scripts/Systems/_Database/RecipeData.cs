using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable]
public struct RecipeInput
{
    public MaterialsData inputItem;
    public int inputAmount;
}

[Serializable]
public struct RecipeOutput
{
    public CraftablesData outputItem;
    public int outputAmount;
}

[CreateAssetMenu(fileName = "New Recipe", menuName = "Database/Recipes")]
public class RecipeData : InventoryItem
{
    [Header("Crafted Item Data")]
    public List<RecipeInput> materialsRequired;
    public RecipeOutput craftedItem;

    public bool isSelected;

    //public CraftablesData outputItem;

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
        builder.Append(useText).AppendLine();
        builder.Append("Max Stack: ").Append(MaxStack).AppendLine();
        builder.Append("Sell Price: ").Append(SellPrice).Append(" Gold");

        return builder.ToString();
    }
}
