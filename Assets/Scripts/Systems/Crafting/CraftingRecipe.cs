using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftingRecipe : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler
{
    public RecipeData recipeData;
    public Button button;
    public TextMeshProUGUI journalEntryLabel;
    public bool isSelected;

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnSelect(BaseEventData eventData)
    {
        isSelected = true;
        //Debug.Log("recipe selected: " + recipeData);
    }


    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
        //Debug.Log(recipeData.itemName + " is deselected");
    }
}