using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBerry : Interactables
{
    public int hungerIncrease = 10;
    public bool isPoisonous;

    private void Start()
    {
        itemName = "Space Berry";
        itemType = ItemType.Berries;
        gameObject.layer = LayerMask.NameToLayer("Item");
    }
    public override void Interact()
    {
        Player player= FindObjectOfType<Player>();

        if (player != null)
        {
            if (isPoisonous)
            {
                player.GetHungry(hungerIncrease); //increases the hunger bar
            }
            else
            {
                player.Eat(hungerIncrease); //increases the hunger bar
                //Inventory.instance.AddItem(this); // adds the item to the inventory if hunger is full

            }
            Destroy(gameObject); //destroys the berry once the player interacts with it 
        }
    }
}
