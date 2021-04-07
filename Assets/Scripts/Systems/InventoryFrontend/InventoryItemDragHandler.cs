using UnityEngine;
using UnityEngine.EventSystems;

//placed on the inventory slot!!
public class InventoryItemDragHandler : ItemDragHandler
{
    [SerializeField] private DestroyItems destroyItems = null;
    public override void OnPointerUp(PointerEventData eventData)
    {
        //adds additional funtionality to OnPoiterUp
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            base.OnPointerUp(eventData);

            if (eventData.hovered.Count == 0)
            {
                InventorySlot thisSlot = itemSlotUI as InventorySlot;
                destroyItems.DestroyPrompt(thisSlot.ItemSlot, thisSlot.ItemSlotIndex);
                //TODO: releasing over open space destroys or drops the item 
                //Implement a confirmation window if there's time.
            }
        }
    }
}
