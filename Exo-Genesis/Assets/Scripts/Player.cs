using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    // Player-specific attributes and methods
    public int oxygenDecreaseRate = 1; // Amount of oxygen to decrease per second
    public int hungerIncreaseRate = 1; // Amount of hunger to increase per second
    public int thirstIncreaseRate = 1; // Amount of thirst to increase per second
    public int healthtDecreaseRate = 1; // Amount of health to decrease per second

    private float oxygenTimer = 0f;
    private float hungerTimer = 0f;
    private float thirstTimer = 0f;
    private float healthTimer = 0f;

    public HealthBar healthBar;
    public HealthBar hungerBar;
    public HealthBar thirstBar;
    public HealthBar oxygenBar;

    private Animator animator;


    public int score;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        healthBar.SetMaxHealth(maxHealth);
        hungerBar.SetMaxHealth(minHunger);
        thirstBar.SetMaxHealth(minThirst);
        oxygenBar.SetMaxHealth(maxOxygen);
    }


    void Update()
    {
        oxygenTimer += Time.deltaTime;
        hungerTimer += Time.deltaTime;
        thirstTimer += Time.deltaTime;
        healthTimer += Time.deltaTime;
        // Decrease oxygen every second
        if (oxygenTimer >= 1f)
        {
            if (currentOxygen > 0)
            {
                Asphyxiating(oxygenDecreaseRate);
                oxygenBar.SetHealth(currentOxygen);
            }
            oxygenTimer = 0f; // Reset the timer
        }

        // Increase hunger every second
        if (hungerTimer >= 1f)
        {
            GetHungry(hungerIncreaseRate);
            hungerBar.SetHealth(currentHunger);
            hungerTimer = 0f; // Reset the timer
        }

        // Increase thirst every second
        if (thirstTimer >= 1f)
        {
            GetThirsty(thirstIncreaseRate);
            thirstBar.SetHealth(currentThirst);
            thirstTimer = 0f; // Reset the timer
        }

        if (healthTimer >= 1f)
        {
            TakeDamage(healthtDecreaseRate);
            healthTimer = 0f;
            healthBar.SetHealth(currentHealth);
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

        if (currentHealth == 0)
        {
            animator.SetBool("IsDead", true);
        }
    }

    void HandleDeath() {
        PlayerPrefs.SetInt("PlayerScore", score); // Save the score

        SceneManager.LoadScene("EndScreen"); // load end screen with score and such
    }
}

