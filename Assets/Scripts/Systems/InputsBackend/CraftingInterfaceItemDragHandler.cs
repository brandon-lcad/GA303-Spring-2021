using UnityEngine.EventSystems;

public class CraftingInterfaceItemDragHandler : ItemDragHandler
{

    //this allows an inout to be cleared from it's interface without destroying it
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            base.OnPointerUp(eventData);

            if (eventData.hovered.Count == 0)
            {
                (ItemSlotUI as CraftingInterfaceSlot).StoredItem = null;
            }
        }
    }
}
