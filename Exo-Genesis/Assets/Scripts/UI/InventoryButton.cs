using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public GameObject inventoryCanvas;  
    public Image inventoryIcon;        
    public Sprite openInventoryIcon;    
    public Sprite closedInventoryIcon;  
    private bool isInventoryOpen = false;


    public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;  

        if (isInventoryOpen)
        {
            inventoryCanvas.SetActive(true);  
            inventoryIcon.sprite = openInventoryIcon;  
        }
        else
        {
            inventoryCanvas.SetActive(false); 
            inventoryIcon.sprite = closedInventoryIcon;  
        }
    }
}
