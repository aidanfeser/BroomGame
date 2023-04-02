using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = startHealth;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("take" + damage + "damage");

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
