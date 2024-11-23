using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Interactables : MonoBehaviour
{
    public string itemName; //name of the item
    public ItemType itemType; // type of item
    public bool showInInventory = true;
    public Sprite icon;

    private void Awake()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        //to make it's set as a trigger
        boxCollider.isTrigger = true;
        icon = GetComponent<Sprite>();
    }

   
    public virtual void Interact()
    {
       Inventory.instance.AddItem(this);
       Destroy(gameObject);
    }

    //to remove the item from inventory
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
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