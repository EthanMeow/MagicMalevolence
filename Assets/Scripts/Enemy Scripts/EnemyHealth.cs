using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy
    private int currentHealth;   // Current health of the enemy

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health when the enemy is created
    }

    // Function to reduce the enemy's health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce health by the damage amount

        // Check if health is less than or equal to 0
        if (currentHealth <= 0)
        {
            Die(); // If health is 0 or less, call the Die function
        }
    }

    // Function to handle the enemy's death
    void Die()
    {
        // Destroy the enemy gameObject
        Destroy(gameObject);
    }
}