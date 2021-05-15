using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "new Container", menuName = "Systems/Container")]
public class Inventory : ScriptableObject
{
    [Header("Player Currency Panel")]
    public TextMeshProUGUI goldAmountLabel;
    public int goldAmount;
    public TextMeshProUGUI reagentAmountLabel;
    public int reagentAmount;
    public TextMeshProUGUI crystalAmountLabel;
    public int crystalAmount;

    public List<InventoryItem> inventoryItems;
    public int ContainerSize() => inventoryItems.Count -1;
}
