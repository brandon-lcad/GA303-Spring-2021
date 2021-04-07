using System;

//fifth script

//Contents used to be the "Inventory" script but was 
//later changed to accomodate a more flexible system 
[Serializable]
public class ItemContainer : IItemContainer
{
    private ItemSlot[] itemSlots = new ItemSlot[0];

    public Action OnItemsUpdated = delegate { };

    public ItemContainer(int size) => itemSlots = new ItemSlot[size];

    //only passes the requested slot, not the entire array
    public ItemSlot GetSlotByIndex(int index) => itemSlots[index];

    public ItemSlot AddItem(ItemSlot itemSlot)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item != null)
            {
                if (itemSlots[i].item == itemSlot.item)
                {
                    int maxStackRemaining = itemSlots[i].item.MaxStack - itemSlots[i].quantity;
                    
                    if (itemSlot.quantity <= maxStackRemaining)
                    {
                        itemSlots[i].quantity += itemSlot.quantity;
                        itemSlot.quantity = 0;

                        OnItemsUpdated.Invoke();

                        return itemSlot;
                    }
                    else if (maxStackRemaining > 0)
                    {
                        itemSlots[i].quantity += maxStackRemaining;
                        itemSlot.quantity -= maxStackRemaining;

                    }
                }
            }
        }

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == null)
            {
                if (itemSlot.quantity <= itemSlot.item.MaxStack)
                {
                    itemSlots[i] = itemSlot;

                    itemSlot.quantity = 0;

                    //invoke event here
                    OnItemsUpdated.Invoke();

                    return itemSlot;
                }
                else
                {
                    itemSlots[i] = new ItemSlot(itemSlot.item, itemSlot.item.MaxStack);
                    itemSlot.quantity -= itemSlot.item.MaxStack;
                }
            }
        }

        //invoke event here
        OnItemsUpdated.Invoke();

        return itemSlot;
    }

    public void RemoveItem(ItemSlot itemSlot)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item != null)
            {
                if (itemSlots[i].item == itemSlot.item)
                {
                    if (itemSlots[i].quantity < itemSlot.quantity)
                    {
                        itemSlot.quantity -= itemSlots[i].quantity;

                        itemSlots[i] = new ItemSlot();
                    }
                    else
                    {
                        itemSlots[i].quantity -= itemSlot.quantity;

                        if (itemSlots[i].quantity == 0)
                        {
                            itemSlots[i] = new ItemSlot();

                            //invoke event here
                            OnItemsUpdated.Invoke();
                            return;
                        }
                    }
                }
            }
        }
    }

    public void RemoveAt(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex > itemSlots.Length - 1) { return; }

        itemSlots[slotIndex] = new ItemSlot();

        //invoke event here
        OnItemsUpdated.Invoke();
    }

    public int GetTotalQuantity(InventoryItem item)
    {
        int totalCount = 0;
        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (itemSlot.item == null) { continue; }
            if (itemSlot.item != item) { continue; }

            totalCount += itemSlot.quantity;
        }
        return totalCount;
    }

    public bool HasItem(InventoryItem item)
    {
        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (itemSlot.item == null) { continue; }
            if (itemSlot.item != item) { continue; }

            return true;
        }
        return false; ;
    }

    //public void FindItem(InventoryItem item)
    //{
    //    throw new System.NotImplementedException();
    //}

    public void SwapItem(int indexOne, int indexTwo)
    {
        
        //Stack items if they are stackable.
        ItemSlot firstSlot = itemSlots[indexOne];
        ItemSlot secondSlot = itemSlots[indexTwo];

        if (firstSlot == secondSlot) { return; }

        if(secondSlot.item != null)
        {
            if(firstSlot.item == secondSlot.item)
            {
                int completeMaxStack = secondSlot.item.MaxStack - secondSlot.quantity;
                if(firstSlot.quantity <= completeMaxStack)
                {
                    itemSlots[indexTwo].quantity += firstSlot.quantity;

                    itemSlots[indexOne] = new ItemSlot();

                    //invoke event here
                    OnItemsUpdated.Invoke();
                    return;
                }
            }
        }
        //switch item location if items are not stackable
        itemSlots[indexOne] = secondSlot;
        itemSlots[indexTwo] = firstSlot;

        //invoke event here
        OnItemsUpdated.Invoke();
    }
}
