using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damageAmount = 20; // Amount of damage the enemy deals to the player

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damageAmount);
            }
        }
    }
}
