using System;
using System.Collections;
using System.Collections.Generic;
using Scriptables;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest : MonoBehaviour
{
    private readonly QuestData settings;
    private readonly Inventory inventory;

    public Image icon;
    public TextMeshProUGUI description;
    public int objective;
    public int objQuantity;
    

    public Button questAcceptButton;
    public TextMeshProUGUI questAcceptLabel;
    public bool isAccepted;
    public bool isComplete;    

    public TextMeshProUGUI reward; // not sure what this is yet.

    private void Awake()
    {
        //description.text = settings.itemDescription;
        objective = settings.questObjective;
        objQuantity = settings.invQuantity;
        isAccepted = settings.questActive;
    }

    public void AcceptQuest()
    {
        isAccepted = true;

        if(isAccepted)
        {
            questAcceptButton.interactable = false;
            questAcceptLabel.text = "Deliver";
        }
    }

    public void QuestAccepted()
    {
        
    }

    public void CheckProgress()
    {
        // TODO: Figure out how to use inventory here!
        // find items in inventory
        var item = inventory.FindItem(objective);
        
        // compare the count to the objective quantity
        if (item.itemAmount >= objQuantity)
        {
            isComplete = true;
        }
    }

    
}

