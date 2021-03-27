using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : ScriptableObject
{
    public PlayerController playerCtrl;
    public Inventory playerInventory;
    
    public string playerName;
    public Sprite playerImg;
    public string playerTitle;

    public int goldOwned;
    public int silverOwned;
    public int copperOwned;

    
}
