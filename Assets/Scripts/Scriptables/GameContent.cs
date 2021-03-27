using System;
using System.Collections;
using System.Collections.Generic;
using Settings;
using UnityEditor;
using UnityEngine;

public enum GameContentType { GameItem, Loot, Quest }

/**
 * Abstract class creating all game content that the player can see and interact with.
 */
public abstract class GameContent : ScriptableObject
{
    [ReadOnlyField] public string itemId;
    [ReadOnlyField] private string UID;
    [ReadOnlyField] public string itemName;
    [ReadOnlyField] public ItemType itemType;
    [TextArea(5, 10)] public string itemDescription;
    public Sprite itemIcon;
    
    public void OnValidate()
    {
        if (string.IsNullOrEmpty(itemId))
        {
            GenerateId();
            EditorUtility.SetDirty(this);
        }
    }
    
    /**
     * Generate a unique item id.
     */
    public void GenerateId()
    {
        UID = Guid.NewGuid().ToString();
        string[] nameParts = itemName.Split(' ');
        itemId = itemType.ToString();
        foreach (var word in nameParts)
        {
            itemId += $"-{word}";
        }
        itemId += $"-{UID}";
    }

    public String GetItemId()
    {
        return itemId;
    }

    public String GetUID()
    {
        return UID;
    }
}
