using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBerry : Interactables
{
    public int hungerIncrease = 10;
    
    private void Start()
    {
        itemName = "Space Berry";
        itemType = ItemType.Berries;
    }
    public override void Interact()
    {
        Player player= FindObjectOfType<Player>();

        if (player != null)
        {
                player.GetHungry(hungerIncrease); //increases the hunger bar
                Inventory.instance.AddItem(this); // adds the item to the inventory if hunger is full
                Destroy(gameObject); //destroys the berry once the player interacts with it 
        }
    }
}
