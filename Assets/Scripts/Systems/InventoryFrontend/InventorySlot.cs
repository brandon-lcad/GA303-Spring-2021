using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : ItemSlotUI, IDropHandler
{
    [SerializeField] private Inventory inventory = null;
    [SerializeField] private TextMeshProUGUI itemQuantityText = null;

    public override GameData StoredItem
    {
        get { return ItemSlot.item; }
        set { }
    }

    //invokng this pulls straight from inv array
    public ItemSlot ItemSlot => inventory.ItemContainer.GetSlotByIndex(ItemSlotIndex);

    public override void OnDrop(PointerEventData eventData)
    {
        ItemDragHandler itemDragHandler = eventData.pointerDrag.GetComponent<ItemDragHandler>();

        if (itemDragHandler == null) {return; }

        if ((itemDragHandler.ItemSlotUI as InventorySlot) != null)
        {
            inventory.ItemContainer.SwapItem(itemDragHandler.ItemSlotUI.ItemSlotIndex, ItemSlotIndex);
        }
    }

    public override void UpdateSlotUI()
    {
        if (ItemSlot.item == null)
        {
            EnableSlotUI(false);
            return;
        }

        EnableSlotUI(true);

        uiItemIcon.sprite = ItemSlot.item.ItemIcon;
        itemQuantityText.text = ItemSlot.quantity > 0 ? ItemSlot.quantity.ToString() : "";
    }

    protected override void EnableSlotUI(bool enable)
    {
        base.EnableSlotUI(enable);
        itemQuantityText.enabled = enable;
    }
}