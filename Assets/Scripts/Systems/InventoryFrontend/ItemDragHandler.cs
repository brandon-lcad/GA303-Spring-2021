using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class ItemDragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler 
{
    [SerializeField] protected ItemSlotUI itemSlotUI = null;
    //[SerializeField] protected VoidEvent onMouseEndHoverItem = null;
    //[SerializeField] protected GameDataEvent onMouseStartHoverItem = null;

    private CanvasGroup canvasGroup = null;
    private Transform originalParent = null;
    private bool ishovering = false;

    public ItemSlotUI ItemSlotUI
    {
        get
        {
            return itemSlotUI;
        }
    }

    private void Start() => canvasGroup = GetComponent<CanvasGroup>();

    private void OnDisable()
    {
        if (ishovering)
        {
            //invoke event
            //onMouseEndHoverItem.Raise();
            ishovering = false;
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        //== to compare
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //invoke event 
            //onMouseEndHoverItem.Raise();

            originalParent = transform.parent;

            //parents to the "SlotContainer_EGO"
            transform.SetParent(transform.parent.parent);

            //allows drag event to temporarily see whats below it (another slot)
            //instead of the what is being dragged. This way, it knows it's not dropping on
            //itself, but on to whatever is below it
            canvasGroup.blocksRaycasts = false;
        }
    }

    //virtual keyword allows child classes to build upon base declaration
    //without overwriting or mutating the original definition.
    //When called, it will show up in child script as "base. "
    public virtual void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            transform.position = Input.mousePosition;
        }
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
            canvasGroup.blocksRaycasts = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //tells listener that mouse is hovering
        //invoke event
        //onMouseStartHoverItem.Raise(ItemSlotUI.SlotItem);
        ishovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //onMouseEndHoverItem.Raise();
        ishovering = false;
    }
}
