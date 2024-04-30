using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public string playerTag = "Player"; // Tag of the player object
    public float moveSpeed = 5f; // Speed at which the enemy moves towards the player

    private Transform player; // Reference to the player's transform

    void Start()
    {
        // Find the player object using its tag
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    void Update()
    {
        // Check if the player is found
        if (player != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 direction = player.position - transform.position;
            direction.Normalize(); // Normalize the direction vector to have a magnitude of 1

            // Move the enemy towards the player
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        else
        {
            Debug.LogWarning("Player object not found. Make sure it has the correct tag.");
        }
    }
}