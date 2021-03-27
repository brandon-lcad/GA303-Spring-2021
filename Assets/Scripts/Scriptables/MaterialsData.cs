using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Material", menuName = "Item System/Database/Materials")]
public class MaterialsData : GameItem
{
    public void Awake()
    {
        itemType = ItemType.Material;
    }

    public bool isStackable;
    public int stackableQty;
}
