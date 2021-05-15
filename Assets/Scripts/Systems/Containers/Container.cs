using UnityEngine;
using UnityEngine.UI;

public class Container : MonoBehaviour
{
    public Inventory container;
    private UI_ContainerSlot[] containerSlots;


    private void Start()
    {
        containerSlots = gameObject.GetComponentsInChildren<UI_ContainerSlot>();

    }

    private void Update()
    {
        if (container.inventoryItems.Count > 0)
        {
            AddItems();
        }
    }

    private void AddItems()
    {
        for (int i = 0; i < container.inventoryItems.Count; i++)
        {
            containerSlots[i].inventoryItem = container.inventoryItems[i];
        }

        //Debug.Log("Item added to this inventory");
    }
}