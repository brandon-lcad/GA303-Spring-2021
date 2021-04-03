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
    public Image journalWindow;
    private bool journalActive;
    public Image ordersWindow;
    private bool ordersActive;
    public Image shopWindow;
    private bool shopActive;


    // Start is called before the first frame update
    void Start()
    {
        journalActive = false;
        ordersActive = false;
        shopActive = false;
    }

    private void FixedUpdate()
    {
        clockDisplay.text = DateTime.Now.ToString("HH:mm");
    }


    public void ShowHideJournalWindow()
    {
        journalActive = !journalActive;
        journalWindow.gameObject.SetActive(journalActive);
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
}


    

 

    