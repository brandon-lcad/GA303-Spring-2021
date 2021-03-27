using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
    Quest
}

public enum ItemQuality
{
    Junk,
    Common,
    Uncommon,
    Rare,
    Null
}

public class GameItem : GameContent
{
    public Profession profession;
}


//create method to gen id from iType
