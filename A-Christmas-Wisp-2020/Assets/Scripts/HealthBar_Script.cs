using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Script : MonoBehaviour
{
    public Slider slider;

    // Max Health (Player)
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Set the health
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
