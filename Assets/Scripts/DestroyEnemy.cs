using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {

        //Debug.Log("it has hit");
        // Check if the projectile collided with an object tagged as "Enemy"
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("it has destroyed");

            // Destroy the enemy object
            Destroy(other.gameObject);
        }
    }
}
