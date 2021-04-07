using UnityEngine;


//See "ItemContainer" script  for what used to be here. was 
//this script what repurposed to accomodate a more flexible system 


//as a scriptable object, it's job is to store one of LINE 8
[CreateAssetMenu(fileName = "New Player Inventory", menuName = "Systems/Player Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] private VoidEvent onInventoryItemsUpdated = null;
    [SerializeField] private ItemSlot testItemSlot = new ItemSlot();
    public ItemContainer ItemContainer { get; } = new ItemContainer(20);

    public void OnEnable() => ItemContainer.OnItemsUpdated += onInventoryItemsUpdated.Raise;

    public void OnDisable() => ItemContainer.OnItemsUpdated -= onInventoryItemsUpdated.Raise;


    [ContextMenu("Test Add")]
    public void TestAdd()
    {
        ItemContainer.AddItem(testItemSlot);
    }
}
