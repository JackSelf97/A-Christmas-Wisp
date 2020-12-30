using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Script : MonoBehaviour
{
    // Health Bar (Brackeys Video: https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=637s&ab_channel=Brackeys)
    // Variables
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
