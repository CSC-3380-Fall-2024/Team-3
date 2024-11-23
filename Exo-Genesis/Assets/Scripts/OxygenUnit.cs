using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenUnit : Interactables
{
	public int oxygenIncrease = 20; //adds 20pts to the oxygen bar per collected item

	private void Start()
	{
		itemName = "Oxygen Unit";
		itemType= ItemType.Oxygen;
		gameObject.layer = LayerMask.NameToLayer("Item");
	}
	public override void Interact()
	{
		Player player = FindObjectOfType<Player>();

		if (player != null)
		{
			player.GetOxygen(oxygenIncrease); //increases the oxygen for the player
			Debug.Log($"{player.characterName} received {oxygenIncrease} oxygen.");

			Destroy(gameObject); //destroys the object one it is collected 
		}
	}
}