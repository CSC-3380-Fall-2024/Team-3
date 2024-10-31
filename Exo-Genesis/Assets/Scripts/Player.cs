using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Player-specific attributes and methods
    public int oxygenDecreaseRate = 1; // Amount of oxygen to decrease per second
    public int hungerIncreaseRate = 1; // Amount of hunger to increase per second
    public int thirstIncreaseRate = 1; // Amount of thirst to increase per second
    private float oxygenTimer = 0f;
    private float hungerTimer = 0f;
    private float thirstTimer = 0f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }


    void Update()
    {
        oxygenTimer += Time.deltaTime;
        hungerTimer += Time.deltaTime;
        thirstTimer += Time.deltaTime;

        // Decrease oxygen every second
        if (oxygenTimer >= 1f)
        {
            if (currentOxygen > 0)
            {
                Asphyxiating(oxygenDecreaseRate);
            }
            oxygenTimer = 0f; // Reset the timer
        }

        // Increase hunger every second
        if (hungerTimer >= 1f)
        {
            GetHungry(hungerIncreaseRate);
            hungerTimer = 0f; // Reset the timer
        }

        // Increase thirst every second
        if (thirstTimer >= 1f)
        {
            GetThirsty(thirstIncreaseRate);
            thirstTimer = 0f; // Reset the timer
        }
        // Handle out of oxygen scenario
        if (currentOxygen <= 0)
        {
            Debug.Log("Out of oxygen!");
        }

        if (currentHunger <= 0)
        {
            Debug.Log("Starving!");
        }

        if (currentThirst <= 0)
        {
            Debug.Log("Dehydrated!");
        }
    }
}
