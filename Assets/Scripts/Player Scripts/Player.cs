using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    public int PlayermaxHealth = 100;
    public int PlayercurrentHealth;

    public HealthBar healthBar;

    public float dashSpeed = 10f; // Speed to set during dash
    public float dashDuration = 1f; // Duration of the dash in seconds
    public float dashCooldown = 5f; // Cooldown between dashes in seconds
    public float invulnerabilityDuration = 1f; // Duration of invulnerability frames after taking damage

    private float originalSpeed; // Store original player speed
    private bool canDash = true; // Flag to check if player can dash
    private float lastDashTime; // Time when the last dash occurred
    private bool isInvulnerable = false; // Flag to check if the player is currently invulnerable
    private float lastDamageTime; // Time when the player last took damage

    void Start()
    {
        PlayercurrentHealth = PlayermaxHealth;
        healthBar.SetMaxHealth(PlayermaxHealth);
        originalSpeed = GetComponent<PlayerMovement>().moveSpeed; // Get original player speed from PlayerMovement script
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(20);
        }

        if (PlayercurrentHealth <= 0)
        {
            Die();
        }

        // Check if the player is currently invulnerable
        if (isInvulnerable)
        {
            // Check if the invulnerability duration has passed
            if (Time.time - lastDamageTime >= invulnerabilityDuration)
            {
                isInvulnerable = false; // Disable invulnerability frames
            }
        }
    }

    public void TakeDamage(int damage)
    {
        // Check if the player is currently invulnerable
        if (!isInvulnerable)
        {
            PlayercurrentHealth -= damage;
            healthBar.SetHealth(PlayercurrentHealth);

            // Enable invulnerability frames
            isInvulnerable = true;
            lastDamageTime = Time.time;
        }
    }

    void Die()
    {
        SceneManager.LoadScene("Death");
    }

    IEnumerator Dash()
    {
        canDash = false; // Disable dashing during cooldown
        lastDashTime = Time.time; // Record the time of the current dash

        // Store original player speed
        float originalSpeed = GetComponent<PlayerMovement>().moveSpeed;

        // Set player speed to dashSpeed
        GetComponent<PlayerMovement>().moveSpeed = dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        // Reset player speed to original value after dashDuration
        GetComponent<PlayerMovement>().moveSpeed = originalSpeed;

        // Wait for the cooldown duration
        yield return new WaitForSeconds(dashCooldown);

        canDash = true; // Allow dashing again after cooldown
    }

    public float GetDashCooldownRemaining()
    {
        if (canDash)
        {
            return 0f; // Dash is available, so cooldown is zero
        }
        else
        {
            return Mathf.Max(0f, dashCooldown - (Time.time - lastDashTime)); // Calculate remaining cooldown time
        }
    }
}