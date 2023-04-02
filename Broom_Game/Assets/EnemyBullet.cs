using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float destroyTime = 3f;

    public int damage = 10;

    public float cooldown = 0.1f;
    private bool canHit = true;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canHit)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log(damage);
            }

            canHit = false;
            StartCoroutine(CooldownTimer());
            Destroy(gameObject);
        }

    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(cooldown);
        canHit = true;
    }
}
