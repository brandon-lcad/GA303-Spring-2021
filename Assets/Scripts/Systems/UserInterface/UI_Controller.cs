using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public TextMeshProUGUI clockDisplay;
    public Canvas inventoryWindow;
    public Canvas ordersWindow;
    public Canvas shopWindow;
    private bool inventoryActive = false;
    private bool ordersActive = false;
    private bool shopActive = false;

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        clockDisplay.text = DateTime.Now.ToString("HH:mm");
    }

    public void ShowHideInventoryWindow()
    {
        inventoryActive = !inventoryActive;
        inventoryWindow.gameObject.SetActive(inventoryActive);
    }
    
    public void ShowHideOrdersWindow()
    {
        ordersActive = !ordersActive;
        ordersWindow.gameObject.SetActive(ordersActive);
    }
    
    public void ShowHideShopWindow()
    {
        shopActive = !shopActive;
        shopWindow.gameObject.SetActive(shopActive);
    }

    /*public void DestroyPrompt(ItemSlot toDestroy, int slotIndex)
    {
        this.slotIndex = slotIndex;

        confirmationPrompt.text = $"Are you sure you'd like to destroy {toDestroy.quantity}X {toDestroy.item.NameTint}?";

        gameObject.SetActive(true);
    }

    public void DestroyConfirm()
    {
        inventory.ContainerCtrl.RemoveAt(slotIndex);
        gameObject.SetActive(false);
    }*/
}


    

 

    