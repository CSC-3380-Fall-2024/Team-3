using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBerry : Interactables
{
    // the amount of hunger and health that is being reduced 
    public int healthReduction = 15;
    public int hungerReduction = 15;

    public override void Interact()
    {
        Player player = FindObjectOfType<Player>();

        if (player != null)
        {
            player.TakeDamage(healthReduction);
            player.GetHungry(hungerReduction);
        }
        Destroy(gameObject);
    }
}
