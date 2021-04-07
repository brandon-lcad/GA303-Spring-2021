using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UI_Controller : MonoBehaviour
{
    public TextMeshProUGUI clockDisplay;
    public Canvas journalWindow;
    public Canvas ordersWindow;
    public Canvas shopWindow;

    private void Start()
    {
        journalWindow.enabled = false;
        ordersWindow.enabled = false;
        shopWindow.enabled = false;
    }

    private void FixedUpdate()
    {
        clockDisplay.text = DateTime.Now.ToString("HH:mm");

    }

    public void ShowHideJournalWindow()
    {
        journalWindow.enabled = !journalWindow.enabled;
    }
    
    public void ShowHideOrdersWindow()
    {
        ordersWindow.enabled = !ordersWindow.enabled;
    }
    
    public void ShowHideShopWindow()
    {
        shopWindow.enabled = !shopWindow.enabled;
    }
}


    

 

    