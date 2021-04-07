using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


//base class for every type of slot available to a game
//inventory, loot containers, spell bar, etc
public abstract class ItemSlotUI : MonoBehaviour, IDropHandler
{
    //using protected to make this accessible only through child classes
    [SerializeField] protected Image uiItemIcon = null;
    //set the index here and reference elsewhere
    public int ItemSlotIndex { get; private set; }

    //Tell slot what and where the item is referenced from
    public abstract GameData StoredItem { get; set; }

    //call this refresh ui each time inventory is opened due to OnEnable
    private void OnEnable() => UpdateSlotUI();

    //called at opening invUI
    protected virtual void Start()
    {
        //this function is a buitin for checking where we are in a heirarchy
        ItemSlotIndex = transform.GetSiblingIndex();
        //used twice to know the index in order to set it
        UpdateSlotUI();
    }

    public abstract void OnDrop(PointerEventData eventData);
    public abstract void UpdateSlotUI();
    protected virtual void EnableSlotUI(bool enable) => uiItemIcon.enabled = enable;
}
