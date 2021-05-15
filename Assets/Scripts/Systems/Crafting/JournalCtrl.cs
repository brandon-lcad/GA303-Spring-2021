using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class JournalCtrl : MonoBehaviour
{
    public List<RecipeData> availableRecipes;
    public List<CraftingRecipe> recipeObjectList;
    public CraftingCtrl craftingCtrl;
    public RecipeData selectedRecipe;

    public GameObject entryList;
    public GameObject entryPrefab;

    void Start()
    {
        LoadJournal();
        EntryData();
    }

    public void LoadJournal()
    {
        var journalEntries = Resources.LoadAll<RecipeData>("Scriptable Objects/Recipes");

        foreach (var entry in journalEntries)
        {
            availableRecipes.Add(entry);

        }
    }

    public void EntryData()
    {
        foreach (var entry in availableRecipes)
        {
            var newEntry = Instantiate(entryPrefab, entryList.transform, false);
            var entryObject = newEntry.GetComponent<CraftingRecipe>();

            entryObject.GetComponentInChildren<TextMeshProUGUI>();
            entryObject.journalEntryLabel.text = entry.itemName;
            entryObject.isSelected = false;
            entryObject.recipeData = entry;

            recipeObjectList.Add(entryObject);
        }
    }
    public void SelectedRecipe()
    {
        foreach (var entry in recipeObjectList)
        {
            if (entry.isSelected)
            {
                selectedRecipe = entry.recipeData;

                //Debug.Log("CraftingCtrl: " + selectedRecipe);
            }
        }
    }
}
