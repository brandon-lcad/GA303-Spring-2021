using TMPro;
using UnityEngine;

public class DestroyItems : MonoBehaviour
{
    [SerializeField] private Inventory inventory = null;
    [SerializeField] private TextMeshProUGUI confirmationPrompt = null;

    private int slotIndex = 0;

    private void OnDisable() => slotIndex = -1;

    public void DestroyPrompt(ItemSlot toDestroy, int slotIndex)
    {
        this.slotIndex = slotIndex;

        confirmationPrompt.text = $"Are you sure you'd like to destroy {toDestroy.quantity}X {toDestroy.item.NameTint}?";

        gameObject.SetActive(true);
    }

    public void DestroyConfirm()
    {
        inventory.ItemContainer.RemoveAt(slotIndex);
        gameObject.SetActive(false);
    }
}
