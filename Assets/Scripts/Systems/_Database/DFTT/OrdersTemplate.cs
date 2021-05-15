using System;
using UnityEngine;

public enum OrderType
{
    Timed,
    Casual,
    Progression,
    Bonus
}

public enum RewardType
{
    Currency,
    Reputation,
    Reagent
}


public abstract class OrdersTemplate : ScriptableObject
{
    [Header("Basic Info")]
    [SerializeField] private Sprite npcIcon = null;
    [SerializeField] private string npcName = "New Order";
    
    public Sprite NpcIcon => npcIcon;
    public string NpcName => npcName;
    

    public OrderType orderType;
    public RewardType rewardType;
    public int rewardAmount;
    public Sprite rewardImage;

    [TextArea(5, 10)]
    public string orderDescription;
    private bool hasUID;
    public int orderId;

    public void OnValidate()
    {
        //assume that, because item is newly created, that the item has no ID.
        if (hasUID == false)
        {
            orderId = GenerateId();
        }
        hasUID = true;
    }

    //figure out later how to use guid instead to understand Chris' example...
    private int GenerateId()
    {
        DateTime idRequested = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        int idAssiged = (int)(DateTime.UtcNow - idRequested).TotalSeconds;
        int uid = UnityEngine.Random.Range(1001, 9999);
        int itemId = idAssiged + uid;
        return itemId;
    }
}