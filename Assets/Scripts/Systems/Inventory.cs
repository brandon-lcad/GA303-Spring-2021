using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ScriptableObject, IItemContainer
{
    private ItemSlot[] itemSlots = new ItemSlot[15];
    public Action OnItemsUpdated = delegate { };

    public int GetTotalQuantity(InventoryItem item)
    {
        int totalCount = 0;
        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (itemSlot.item == null) { continue; }
            if (itemSlot.item != item) { continue; }

            totalCount += itemSlot.itemQuantity;
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

    public ItemSlot AddItem(ItemSlot itemSlot)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item != null)
            {
                if (itemSlots[i].item == itemSlot.item)
                {
                    int maxStackRemaining = itemSlots[i].item.MaxStack - itemSlots[i].itemQuantity;
                    if(itemSlot.itemQuantity <= maxStackRemaining)
                    {
                        itemSlots[i].itemQuantity += itemSlot.itemQuantity;
                        itemSlot.itemQuantity = 0;

                        OnItemsUpdated.Invoke();
                        return itemSlot;
                    } else
                    {
                        if (maxStackRemaining > 0)
                        {
                            itemSlots[i].itemQuantity += maxStackRemaining;
                            itemSlot.itemQuantity -= maxStackRemaining;

                        }
                    }
                }
            }
        }

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].item == null)
            {
                if (itemSlot.itemQuantity <= itemSlot.item.MaxStack)
                {
                    itemSlots[i] = itemSlot;

                    itemSlot.itemQuantity = 0;

                    //invoke event here
                    OnItemsUpdated.Invoke();

                    return itemSlot;
                } else
                {
                    itemSlots[i] = new ItemSlot(itemSlot.item, itemSlot.item.MaxStack);
                    itemSlot.itemQuantity -= itemSlot.item.MaxStack;
                }
            }
        }

        //invoke event here
        OnItemsUpdated.Invoke();

        return itemSlot;
    }

    public void FindItem(InventoryItem item)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveAt(int slotIndex)
    {
        if(slotIndex < 0 || slotIndex > itemSlots.Length - 1) { return; }
        itemSlots[slotIndex] = new ItemSlot();

    }

    public void RemoveItem(ItemSlot itemSlot)
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].item != null)
            {
                if(itemSlots[i].item == itemSlot.item)
                {
                    if(itemSlots[i].itemQuantity < itemSlot.itemQuantity)
                    {
                        itemSlot.itemQuantity -= itemSlots[i].itemQuantity;
                    } else
                    {
                        itemSlots[i].itemQuantity -= itemSlot.itemQuantity;
                        if(itemSlots[i].itemQuantity == 0)
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
                int completeMaxStack = secondSlot.item.MaxStack - secondSlot.itemQuantity;
                if(firstSlot.itemQuantity <= completeMaxStack)
                {
                    itemSlots[indexTwo].itemQuantity += firstSlot.itemQuantity;
                    itemSlots[indexOne] = new ItemSlot();
                    return;
                }
            }

            //switch item location if items are not stackable
            itemSlots[indexOne] = secondSlot;
            itemSlots[indexTwo] = firstSlot;
        }
    }
}
