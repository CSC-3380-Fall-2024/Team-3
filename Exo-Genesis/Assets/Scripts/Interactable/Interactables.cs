using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Interactables : MonoBehaviour
{

    private void Awake()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        //to make it's set as a trigger
        boxCollider.isTrigger = true;
    }

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