using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum Profession
{
    Alchemy,
    Blacksmithing,
    Enchanting,
    Tailoring
}
public enum ItemType
{
    Material,
    Craftable,
    Reagent,
    Recipe,
    Order
}



public abstract class GameData : ScriptableObject
{
    [Header("Basic Info")]
    [SerializeField] private string itemName = "New Database Item";
    [SerializeField] private Sprite itemIcon;
    
    public abstract string NameTint { get; }
    public string ItemName => itemName;
    public Sprite ItemIcon => itemIcon;
    public Profession profession;
    public ItemType itemType;
    [TextArea(2, 5)]
    public string itemDescription;
    private bool hasUID;
    public int itemId;

    public void OnValidate()
    {
        //assume, because item is newly created, that the item has no ID.
        if (hasUID == false)
        {
            itemId = GenerateId();
        }
        hasUID = true;
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

    public abstract string GetInfoDisplayText();
}
