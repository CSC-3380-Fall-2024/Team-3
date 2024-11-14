using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : Interactables
{
	public int healthIncrease= 25; //adds 25pts to the health bar of the player

	private void Start() 
	{
		itemName = "Health Pack"; //name of the item can be changed to whatever we want
		itemType = ItemType.Health;
		gameObject.layer = LayerMask.NameToLayer("Item");
	}

	public override void Interact()
	{
		Player player = FindObjectOfType<Player>();
		if(player != null)
		{
			player.Heal(healthIncrease);
			Debug.Log($"{player.characterName} received {healthIncrease} health.");
			Destroy(gameObject); //destroys the object after it is picked up 
		}
	}
}