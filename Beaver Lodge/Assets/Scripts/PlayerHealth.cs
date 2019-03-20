using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;
    public Text lives;

    public float maxHealth { get; set; }
    public float currentHealth { get; set; }

    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

        maxHealth = 20f;
        currentHealth = maxHealth;

        healthBar.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        if (t > 2f)
            DealDamage(1);
    }

   private void DealDamage(float damageValue)
    {
        startTime = Time.time;

        currentHealth -= damageValue;
        healthBar.value = CalculateHealth();

        if (currentHealth <= 0)
            Die();
    }

    private float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }

    public void Eat()
    {
        currentHealth += 5f;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        healthBar.value = CalculateHealth();
    }

    public void Die()
    {
        if (lives.text == "♥♥♥")
        {
            lives.text = "♥♥";
            Debug.Log("You lost a life!");
            currentHealth = 20f;
            healthBar.value = CalculateHealth();
        }
        else if (lives.text == "♥♥")
        {
            lives.text = "♥";
            Debug.Log("You lost a life!");
            currentHealth = 20f;
            healthBar.value = CalculateHealth();
        }
        else if (lives.text == "♥")
        {
            lives.text = "";
            Debug.Log("You're dead!");
            currentHealth = 0f;
            healthBar.value = CalculateHealth();
        }
    }
}
