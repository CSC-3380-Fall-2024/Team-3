using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public string itemName; //name of the item
    public ItemType itemType; // type of item

    public virtual void Interact()
    {

       Inventory.instance.AddItem(this);
       Destroy(gameObject);
    }
}

public enum ItemType
{
    Weapons,
    Berries,
    Oxygen,
    Health,
    Water, 
    Tools
    //can add more 
}