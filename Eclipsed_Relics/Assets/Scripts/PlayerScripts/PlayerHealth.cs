using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    public float maxScale = 1.5f; // Adjusted to make the bar shorter

    [SerializeField] private GameObject healthBar;
    [SerializeField] public GameObject game;

    void Start()
    {
        health = maxHealth;

        // Assign the health bar objects (if not already assigned)
        healthBar = GameObject.FindGameObjectWithTag("HealthBar");

        // Set both bars to their full scale initially
        healthBar.transform.localScale = new Vector3(maxScale, 0.2f, 1f); // Green bar
    }

    void Update()
    {
        if (healthBar != null)
        {
            // Position both bars above the player
            healthBar.transform.position = transform.position + new Vector3(0, 0.8f, 0); // Green bar

            // Prevent rotation for both bars
            healthBar.transform.rotation = Quaternion.identity;
        }
    }
    
    public void PlayerDied()
    {
        Destroy(gameObject);
        game.GetComponent<GameController>().PlayerDied();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateScale();

        if (health <= 0)
        {
            PlayerDied();
        }
    }

    void UpdateScale()
    {
        // Shrink the green health bar as health decreases
        float healthPercent = (float)health / maxHealth;
        healthBar.transform.localScale = new Vector3(maxScale * healthPercent, 0.2f, 1f); // Green bar shrinking
    }
}
