using UnityEngine;

//hotbar
public class CraftingInterface : MonoBehaviour
{
    [SerializeField] private CraftingInterfaceSlot[] inputSlots = new CraftingInterfaceSlot[3];

    public void Add(GameData itemToAdd)
    {
        foreach (CraftingInterfaceSlot craftingInterfaceSlot in inputSlots)
        {
            if(craftingInterfaceSlot.AddItem(itemToAdd)) { return; }
        }
    }
}
