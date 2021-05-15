using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_ContainerSlot : MonoBehaviour
{
    //ItemModel item
    public InventoryItem inventoryItem;
    public Image containerIcon;
    public TextMeshProUGUI containerQty;

    private void Update()
    {
        if (inventoryItem != null)
        {
            containerIcon.enabled = true;
            DisplayItem();
        }
        else
        {
            containerIcon.enabled = false;
            containerIcon.sprite = null;
        }
    }

    public void DisplayItem()
    {
        containerIcon.sprite = inventoryItem.itemIcon;
    }
}
