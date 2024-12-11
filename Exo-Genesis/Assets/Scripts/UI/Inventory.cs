using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private void Awake(){

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;


    //bigger list with all the items inside
    public List<Interactables> interactables = new List<Interactables>();

    //organize into different categories
    public List<Interactables> food = new List<Interactables>();
    public List<Interactables> weapons = new List<Interactables>();
    public List<Interactables> supplies = new List<Interactables>();

    public int space = 25;	//nb of item spaces


    //adds the item based on its category
    public void AddItem(Interactables item){

        if (item.showInInventory)
        {
            if (interactables.Count >= space)
            {
                Debug.Log("already too many items");
                return;
            }
        }
        switch (item.itemType){
            case ItemType.Berries:
                food.Add(item);
                interactables.Add(item);
                Debug.Log($"Added {item.itemName} to Food.");
                break;
            case ItemType.Weapons:
                weapons.Add(item);
                interactables.Add(item);
                Debug.Log($"Added {item.itemName} to Weapons.");
                break;
            case ItemType.Tools:
                supplies.Add(item);
                interactables.Add(item);
                Debug.Log($"Added {item.itemName} to Supplies.");
                break;
            default:
                Debug.LogWarning("Item type not recognized.");
                break;
        }
    }

    // Remove an item
    public void Remove(Interactables item)
    {
        switch (item.itemType)
        {
            case ItemType.Berries:
                food.Remove(item);
                interactables.Remove(item);
                Debug.Log($"Removed {item.itemName} to Food.");
                break;
            case ItemType.Weapons:
                weapons.Remove(item);
                interactables.Remove(item);
                Debug.Log($"Removed {item.itemName} to Weapons.");
                break;
            case ItemType.Tools:
                supplies.Remove(item);
                interactables.Remove(item);
                Debug.Log($"Removed {item.itemName} to Supplies.");
                break;
            default:
                Debug.LogWarning("Item type not recognized.");
                break;
        }

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }


    //method to display the items depending on the category 
    public void DisplayInventory(){
        Debug.Log("---Inventory---");

        Debug.Log("Food:");
        foreach (var item in food){
            Debug.Log(item.itemName);
        }
        Debug.Log("Weapons:");
        foreach (var item in weapons){
            Debug.Log(item.itemName);
        }
        Debug.Log("Supplies:");
        foreach (var item in supplies){
            Debug.Log(item.itemName);
        }
    }
}