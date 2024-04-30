using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of player movement

    // Update is called once per frame
    void Update()
    {
        // Get input from player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Normalize movement vector to prevent faster diagonal movement
        movement = movement.normalized;

        // Move the player
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
