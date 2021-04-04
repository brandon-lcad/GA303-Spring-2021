using UnityEngine;

[CreateAssetMenu(fileName = "New Player Inventory", menuName = "Systems/Player Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] private VoidEvent onInventoryItemsUpdated = null;
    [SerializeField] private ItemSlot testItem = new ItemSlot();
    public ItemContainer ItemContainer { get; } = new ItemContainer(20);

    public void OnEnable() => ItemContainer.OnInventoryItemsUpdated += onInventoryItemsUpdated.Raise;

    public void OnDisable() => ItemContainer.OnInventoryItemsUpdated -= onInventoryItemsUpdated.Raise;

    [ContextMenu("Test Add")]
    public void TestAdd()
    {
        ItemContainer.AddItem(testItem);
    }
}
