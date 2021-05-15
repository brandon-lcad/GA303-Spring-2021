using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Container : MonoBehaviour
{
    public Inventory container;
    private UI_ContainerSlot[] containerSlots;

    public TextMeshProUGUI goldAmountLabel;
    public int goldAmount;
    public TextMeshProUGUI reagentAmountLabel;
    public int reagentAmount;
    public TextMeshProUGUI crystalAmountLabel;
    public int crystalAmount;

    private void Start()
    {
        containerSlots = gameObject.GetComponentsInChildren<UI_ContainerSlot>();
        //container.LoadContainer();
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