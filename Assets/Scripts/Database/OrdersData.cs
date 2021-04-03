using System;
using UnityEngine;

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

    public enum OrderType
    {
        Timed,
        Casual,
        Progression,
        Bonus
    }

    private bool hasUID;

    public string Name;
    public Sprite itemIcon;
    public RewardType rewardType;
    [TextArea(5, 10)]
    public string itemDescription;
    public int orderId;

    // TODO: This is supposed to be a string, right? Or maybe an item object?
    public int questObjective;


    public bool questTimed;
    public bool questActive;
    public int questTimer;
    public bool questComplete;

    public int rewardAmount;
    public Sprite rewardImage;

    public void OnValidate()
    {
        //assume, because item is newly created, that the item has no ID.
        if (!hasUID && orderId == 0)
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