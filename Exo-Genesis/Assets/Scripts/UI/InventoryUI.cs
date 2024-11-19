using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Image inventoryIcon;
    public Sprite openInventoryIcon;
    public Sprite closedInventoryIcon;    
    public GameObject inventoryUI; 
    public Transform itemsParent;   //parent object of all the items

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
    }

    // Check to see if we should open/close the inventory
    public void ToggleInventory()
    {
        Debug.Log("hfsdkoljhgd");
        if (!inventoryUI.activeSelf)
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            inventoryIcon.sprite = openInventoryIcon;
            Debug.Log("open");
            UpdateUI();
        }
        else
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            inventoryIcon.sprite = closedInventoryIcon;
            Debug.Log("close");
            UpdateUI();
        }
    }
    // Update the inventory UI by:
    //		- Adding items
    //		- Clearing empty slots
    // This is called using a delegate on the Inventory.
    public void UpdateUI()
    {
        InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.interactables.Count)
            {
                slots[i].AddIt(inventory.interactables[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

}