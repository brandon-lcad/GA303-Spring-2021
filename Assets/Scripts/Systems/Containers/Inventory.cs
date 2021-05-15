using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new Container", menuName = "Systems/Container")]
public class Inventory : ScriptableObject
{
    public List<InventoryItem> inventoryItems;

    /*public void LoadContainer()
    {
        var containerList = Resources.LoadAll<InventoryItem>("Scriptable Objects/Items");
        foreach (var item in containerList)
        {
            inventoryItems.Add(item);
        }
    }*/
    public int ContainerSize() => inventoryItems.Count -1;
}
