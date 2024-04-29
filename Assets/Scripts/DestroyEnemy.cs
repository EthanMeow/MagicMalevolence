using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20; // Damage inflicted by the bullet

    // Called when the bullet collides with another object
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with is an enemy
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            // If it's an enemy, reduce its health by the bullet's damage
            enemyHealth.TakeDamage(damage);

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
