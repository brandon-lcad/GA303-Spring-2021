using UnityEngine;
using UnityEngine.UI;

public class CraftingSlot : MonoBehaviour
{

    //ItemModel item
    //InventoryItem containerItem;

    public InventoryItem inventoryItem;
    public Image image;

    private void Start()
    {
        if (inventoryItem)
        {
            image.sprite = inventoryItem.itemIcon;
        }

    }
}