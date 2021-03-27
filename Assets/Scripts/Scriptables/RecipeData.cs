using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Game Systems/Recipes")]
public class RecipeData : ScriptableObject
{
    public enum RecipeType
    {
        Alchemy
    }

    public RecipeType recipeType;
    public int recipeID;
    public Sprite recipeImg;
    [TextArea(15, 20)]
    public string recipeDescription;
}
