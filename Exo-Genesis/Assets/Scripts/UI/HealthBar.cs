using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public TextMeshProUGUI healthPercentageText;


    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        UpdateHealthPercentageText(health);
    }

    private void UpdateHealthPercentageText(int health)
    {
            float percentage = (float)health / slider.maxValue * 100;
            healthPercentageText.text = Mathf.RoundToInt(percentage) + "%";
        
    }
}