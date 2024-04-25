using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile
    public float shootingSpeed = 10f; // Speed at which the projectile moves
    public LayerMask enemyLayer; // Layer mask for enemy objects
    public float projectileLifetime = 2f; // Lifetime of the projectile

    void Update()
    {
        // Check for mouse input to shoot
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure z-coordinate is 0 for 2D

        // Calculate the direction from the player to the mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Instantiate the projectile slightly in front of the player to avoid collision with the player
        Vector3 spawnPosition = transform.position + direction * 0.5f;

        // Create the projectile
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        // Set the velocity of the projectile to shoot towards the mouse
        projectile.GetComponent<Rigidbody2D>().velocity = direction * shootingSpeed;

        // Destroy the projectile after some time to prevent memory leaks
        Destroy(projectile, projectileLifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the projectile collided with an object tagged as "Enemy"
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Destroy the enemy object
            Destroy(other.gameObject);
        }
    }
}
