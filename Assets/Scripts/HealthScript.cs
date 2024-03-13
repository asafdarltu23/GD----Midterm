using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public static float maxHealth = 1000;
    public static float Health;

    public HealthBar healthBar;
    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = Health;
        Health = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.setHealth(Health);
        healthBar.setMaxHealth(maxHealth);

        if (Health < currentHealth)
        {
            currentHealth = Health;
        }

        if (Health > maxHealth)
        {
            Health = maxHealth;
        }

        if (Health <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
