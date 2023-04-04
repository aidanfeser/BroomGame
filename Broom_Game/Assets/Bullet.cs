using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyTime = 3f;

    public int damage = 1;

    public float cooldown = 0.1f;
    private bool canHit = true;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && canHit )
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                Debug.Log(damage);
            }

            canHit = false;
            StartCoroutine(CooldownTimer());
            Destroy(gameObject);
        }
        else if (collision.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
        }
    }

   IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(cooldown);
        canHit = true;
    }
}
