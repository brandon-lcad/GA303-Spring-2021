using UnityEngine.EventSystems;

//placed on the inventory slot!!
public class InventoryItemDragHandler : ItemDragHandler
{
    public override void OnPointerUp(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            base.OnPointerUp(eventData);

            if (eventData.hovered.Count == 0)
            {
                //TODO: releasing over open space destroys or drops the item 
                //Implement a confirmation window if there's time.
            }
        }
        
    }
}
