using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Quest", menuName = "Systems/Quests")]
public class OLD_OrderData
{

    public int questObjective; // TODO: This is supposed to be a string, right? Or maybe an item object?
    public int invQuantity;

    public bool questTimed;
    public int questTimer;
    public bool questActive;
    public bool questComplete;

    public int rewardAmount;
    public Sprite rewardImage;
}


[CreateAssetMenu(fileName = "New Order", menuName = "Systems/Orders")]
public abstract class OrderData : ScriptableObject
{
    //[Header("Basic Info")]
    public enum RewardType
    {
        Currency,
        Reputation,
        Reagent
    }

    private bool hasUID;

    public string Name;
    public Sprite itemIcon;
    public RewardType rewardType;
    [TextArea(5, 10)]
    public string itemDescription;
    public int itemId;



    public void OnValidate()
    {
        //assume, because item is newly created, that the item has no ID.
        if (!hasUID)
        {
            hasUID = false;
            GenerateId();
        }
    }

    //figure out later how to use guid instead...
    private int GenerateId()
    {
        DateTime idRequested = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        int idAssiged = (int)(DateTime.UtcNow - idRequested).TotalSeconds;
        int uid = UnityEngine.Random.Range(1001, 9999);
        int itemId = idAssiged + uid;
        return itemId;
    }
}