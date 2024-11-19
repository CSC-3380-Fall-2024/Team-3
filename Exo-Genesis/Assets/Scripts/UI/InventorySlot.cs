using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour
{

    public Image icon;
    public Button removeButton;

    Interactables item;  // Current item in the slot

    // Add item to the slot
    public void AddIt(Interactables newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    // Clear the slot
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    // If the remove button is pressed, this function will be called.
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(item);
    }

    // Use the item
    public void Use()
    {
        if (item != null)
        {
            item.Interact();
        }
    }

}