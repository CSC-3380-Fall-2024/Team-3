using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Public adjastables")]
    public string characterName;
    public int maxHealth = 100;
    public int currentHealth;
    public int minHunger = 100;
    public int currentHunger;
    public int minThirst = 100;
    public int currentThirst;
    public int maxOxygen = 100;
    public int currentOxygen;



    protected virtual void Start()
    {
        currentHealth = maxHealth;
        currentOxygen = maxOxygen;
        currentHunger = minHunger;
        currentThirst = minHunger;
    }


    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
    }


    public void Heal(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }


    public void GetHungry(int hungerAmount)
    {
        currentHunger -= hungerAmount;
    } 


    public void Eat(int foodAmount)
    {
        currentHunger += foodAmount;

        if (currentHunger > minHunger)
        {
            currentHunger = minHunger;
        }
    }


    public void GetThirsty(int thirstAmount)
    {
        currentThirst -= thirstAmount;
    }


    public void Drink(int waterAmount)
    {
        currentThirst += waterAmount;
        if (currentThirst > minThirst)
        {
            currentThirst = minThirst;
        }
    }


    public void Asphyxiating(int oxygenDeprivedAmount)
    {
        currentOxygen -= oxygenDeprivedAmount;
    }


    public void GetOxygen(int oxygenAmount)
    {
        currentOxygen += oxygenAmount;
        if (currentOxygen > maxOxygen)
        {
            currentOxygen = maxOxygen;
        }
    }
}
