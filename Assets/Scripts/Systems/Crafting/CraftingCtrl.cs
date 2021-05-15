using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CraftingCtrl : MonoBehaviour
{
    public Inventory container;
    public JournalCtrl journalCtrl;
    public RecipeData recipeData;
    private MaterialsData materials;

    public bool canCraft;
    private bool startCrafting;


    public Image craftingProgressBar;
    public Canvas craftingProgressDisplay;

    public Canvas playerFeeback;
    public TextMeshProUGUI playerFeebackMessage;

    public Button craftButton;

    private void Start()
    {
        craftingProgressDisplay.gameObject.SetActive(false);
        playerFeebackMessage.gameObject.SetActive(false);
    }

    private void Update()
    {
        journalCtrl.SelectedRecipe();
        recipeData = journalCtrl.selectedRecipe;

        if (startCrafting)
        {
            FillProgressBar();

            if (CraftingComplete())
            {
                container.inventoryItems.Add(recipeData.craftedItem.outputItem);
                startCrafting = false;
                craftingProgressDisplay.gameObject.SetActive(false);
                craftingProgressBar.fillAmount = 0;
                recipeData = null;
            }
        }
    }

    private void FillProgressBar()
    {
        if (startCrafting)
        {
            craftingProgressDisplay.gameObject.SetActive(true);
            craftingProgressBar.fillAmount += 0.0025f;
        }
    }

    private bool CraftingComplete() => craftingProgressBar.fillAmount >= 0.990;
    private bool CanCraft()
    {
        CheckRequirements();
        return canCraft;
    }

    public void CraftRecipe()
    {
        string error_1 = "You don't have enough materials to craft that";
        string error_2 = "Please choose a recipe to craft";
        //CheckRequirements();

        if (CanCraft())
        {
            startCrafting = true;
            UpdateInventory();
        }
        else if(!recipeData) {

            playerFeebackMessage.gameObject.SetActive(true);
            playerFeebackMessage.text = error_2;
            playerFeebackMessage.CrossFadeAlpha(1.0f, 0.0f, true);
            playerFeebackMessage.CrossFadeAlpha(0.0f, 5.0f, false);

        } else {

            playerFeebackMessage.gameObject.SetActive(true);
            playerFeebackMessage.text = error_1;
            playerFeebackMessage.CrossFadeAlpha(1.0f, 0.0f, true);
            playerFeebackMessage.CrossFadeAlpha(0.0f, 5.0f, false);


            craftingProgressBar.fillAmount = 0;
            startCrafting = false;
            craftingProgressDisplay.gameObject.SetActive(false);
        }
    }

    public void CheckRequirements()
    {
        if (recipeData)
        {
            foreach (var recipeInput in recipeData.materialsRequired)
            {
                //Debug.Log("Current recipe: " + recipeData.materialsRequired.Count);
                if (!container.inventoryItems.Contains(recipeInput.inputItem))
                {
                    canCraft = false;
                    return;
                } 
            }

            canCraft = true;
        }
    }

    private void UpdateInventory()
    {
        foreach (var recipeInput in recipeData.materialsRequired)
        {
            //Debug.Log("materials List: " + recipeInput.inputItem);
            materials = recipeInput.inputItem;
            container.inventoryItems.Remove(materials);
        }
    }


    /*private YieldInstruction fadeInstruction = new YieldInstruction();
    IEnumerator FadeOut(Image image)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < fadeTime)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
            image.color = c;
        }
    }

    foreach (Image image in imagesToFade)
    StartCoroutine(FadeOut(image));*/
}

