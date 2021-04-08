using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

//HotbarSlot
public class CraftingInterfaceSlot : ItemSlotUI, IDropHandler
{
    [SerializeField] private Inventory inventory = null;
    [SerializeField] private TextMeshProUGUI itemQuantity = null;

    private GameData craftingInput = null;

    //GamaeData is HotbarItem
    public override GameData StoredItem
    {
        get { return craftingInput; }
        set { craftingInput = value; UpdateSlotUI(); }
    }

    public bool AddItem(GameData itemToAdd)
    {
        if (StoredItem != null) { return false; }

        StoredItem = itemToAdd;

        return true;
    }

    public void UseSlot(int index)
    {
        if (index != ItemSlotIndex) { return; }

    }

    public override void OnDrop(PointerEventData eventData)
    {
        ItemDragHandler itemDragHandler = eventData.pointerDrag.GetComponent<ItemDragHandler>();
        if (itemDragHandler == null) { return; }

        InventorySlot inventorySlot = itemDragHandler.ItemSlotUI as InventorySlot;
        if(inventorySlot != null)
        {
            StoredItem = inventorySlot.ItemSlot.item;
            return;
        }

        CraftingInterfaceSlot craftingSlot = itemDragHandler.ItemSlotUI as CraftingInterfaceSlot;
        if(craftingSlot != null)
        {
            GameData oldItem = StoredItem;
            StoredItem = craftingSlot.StoredItem;
            craftingSlot.StoredItem = oldItem;
            return;
        }
    }

    public override void UpdateSlotUI()
    {
        if(StoredItem == null)
        {
            EnableSlotUI(false);
        }

        uiItemIcon.sprite = StoredItem.ItemIcon;

        EnableSlotUI(true);

        SetItemQuantityUI();
    }

    private void SetItemQuantityUI()
    {
        if (StoredItem is InventoryItem inventoryItem)
        {
            if(inventory.ItemContainer.HasItem(inventoryItem))
            {
                int availableInput = inventory.ItemContainer.GetTotalQuantity(inventoryItem);
                itemQuantity.text = availableInput > 1 ? availableInput.ToString() : "";
            } else { StoredItem = null; }
        }

        else
        {
            itemQuantity.enabled = false;
        }
    }

    protected override void EnableSlotUI(bool enable)
    {
        base.EnableSlotUI(enable);
        itemQuantity.enabled = enable;
    }
}
