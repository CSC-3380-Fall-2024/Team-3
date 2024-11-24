using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Interactables
{
	public int thirstIncrease = 30; //adds 30 pts to thirst bar 

	private void Start()
	{
		itemName = "Water"; //name can be changed if needed 
		itemType = ItemType.Water;
		gameObject.layer = LayerMask.NameToLayer("Item");
	}
	public override void Interact()
	{
		Player player = FindObjectOfType<Player>();

		if (player != null)
		{
			player.Drink(thirstIncrease);
			Debug.Log($"{player.characterName} drank water and added {thirstIncrease} pts to thirst");
			Destroy(gameObject); //destroys the object after interaction
		}
	}
}
