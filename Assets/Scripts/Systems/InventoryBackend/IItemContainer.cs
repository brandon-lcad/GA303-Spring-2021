public interface IItemContainer
{
    ItemSlot AddItem(ItemSlot itemSlot);
    void RemoveItem(ItemSlot itemSlot);
    void RemoveAt(int slotIndex);
    void SwapItem(int indexOne, int indexTwo);
    //void FindItem(InventoryItem item);
    bool HasItem(InventoryItem item);
    int GetTotalQuantity(InventoryItem item);
}
