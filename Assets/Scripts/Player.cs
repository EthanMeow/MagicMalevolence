using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void Die()
    {
        SceneManager.LoadScene("Death");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("The player has collided with enemy" + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
        }

    }

}