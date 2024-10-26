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
//organize into different categories
    private List<Interactables> food = new List<Interactables>();
    private List<Interactables> weapons = new List<Interactables>();
    private List<Interactables> supplies = new List<Interactables>();

    //adds the item based on its category
    public void AddItem(Interactables item){
        switch (item.itemType){
            case ItemType.Berries:
                food.Add(item);
                Debug.Log($"Added {item.itemName} to Food.");
                break;
            case ItemType.Weapons:
                weapons.Add(item);
                Debug.Log($"Added {item.itemName} to Weapons.");
                break;
            case ItemType.Tools:
                supplies.Add(item);
                Debug.Log($"Added {item.itemName} to Supplies.");
                break;
            default:
                Debug.LogWarning("Item type not recognized.");
                break;
        }
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