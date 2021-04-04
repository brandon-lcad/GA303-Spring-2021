using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI clockDisplay;
    public CanvasGroup journalWindow;
    public CanvasGroup ordersWindow;
    public CanvasGroup shopWindow;

    private void Start()
    {
        journalWindow.enabled = false;
        ordersWindow.enabled = false;
        journalWindow.enabled = false;
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


    

 

    