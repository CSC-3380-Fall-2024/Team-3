using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public string itemName; //name of the item
    public ItemType itemType; // type of item

    public void Interact()
    {

       Inventory.instance.AddItem(this);
       Destroy(gameObject);
    }
}

public enum ItemType
{
    Weapons,
    Berries,
    Tools
    //can add more 
}