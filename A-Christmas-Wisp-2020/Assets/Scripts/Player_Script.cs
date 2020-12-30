using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    // Variables
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar_Script healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    // Take Damage
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obsticle")
        {
            TakeDamage(1);
            healthbar.SetHealth(currentHealth);
        }
    }
}
