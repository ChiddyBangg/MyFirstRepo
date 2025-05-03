using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int count = 0;
    public int maxHealth = 50;
    private int currentHealth;
    
    [SerializeField] public GameObject game;

    // New Fields for Health Bar
    public GameObject healthBarPrefab; // The health bar prefab (assign in Inspector)
    private GameObject healthBarInstance;
    private SpriteRenderer RedBarRenderer; // SpriteRenderer for the RedHp

    void Start()
    {

        //Getting object for game
        game = GameObject.FindGameObjectWithTag("GameController");

        currentHealth = maxHealth;

        // Spawn the health bar prefab above the enemy
        healthBarInstance = Instantiate(healthBarPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);

        // Get the SpriteRenderer component from the RedHp sprite (the health bar)
        RedBarRenderer = healthBarInstance.GetComponent<SpriteRenderer>();

        // Initially hide the health bar
        healthBarInstance.SetActive(false);

        // Set the health bar to have an appropriate initial scale (adjust Y as needed)
        healthBarInstance.transform.localScale = new Vector3(1.35f, 0.2f, 1f); // Default scale
    }

    void Update()
    {
        // Keep the health bar above the enemy
        if (healthBarInstance != null)
        {
            healthBarInstance.transform.position = transform.position + new Vector3(0, 1, 0);
           
            // Ensure the health bar is facing the correct direction (not rotated)
            healthBarInstance.transform.rotation = Quaternion.identity; // Prevent any rotation
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Show the health bar when the enemy first takes damage
        if (healthBarInstance != null && !healthBarInstance.activeSelf)
        {
            healthBarInstance.SetActive(true);
        }

        // Update the health bar
        UpdateHealthBar();

        // Log for checking health
        Debug.Log("Enemy health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    void UpdateHealthBar()
    {
        // Calculate the health percentage
        float healthPercent = (float)currentHealth / maxHealth;

        // Update the health bar's width by adjusting its local scale
        if (healthBarInstance != null)
        {
            // Only update the X scale to reflect health percentage, keeping Y fixed
            healthBarInstance.transform.localScale = new Vector3(healthPercent * 1.35f, 0.2f, 1f); // Multiply by initial scale factor to keep proportion
        }
    }


    void Die()
    {
        // Destroy the health bar when the enemy dies
        if (healthBarInstance != null)
        {
            Destroy(healthBarInstance); // Destroy the health bar
        }

        // Destroy the enemy object
        Debug.Log("Enemy died");

        Destroy(gameObject); // Remove enemy from the game
        count = 1;
        game.GetComponent<GameController>().EnemyCount(count);

    }
}