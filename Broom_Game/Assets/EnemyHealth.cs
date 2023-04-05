using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 50;
    public int currentHealth;

    public int damage = 10;

    ScoreManager scoreManager;

    void Start()
    {
        currentHealth = startingHealth;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null) 
            {
                playerHealth.TakeDamage(damage); 
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("take" + damage + "damage");

        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        scoreManager.AddKill();
    }
}
