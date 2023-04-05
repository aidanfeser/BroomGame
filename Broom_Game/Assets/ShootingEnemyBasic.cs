using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyBasic : MonoBehaviour
{
    public GameObject playerTarget;   
    public float shootingRange = 10f;   
    public float shootingDelay = 1f;    
    public GameObject bulletPrefab;     
    public Transform bulletSpawnPoint;  
    
    private bool canShoot = true;

    public GameObject enemySpawner;
    public GameObject enemyPrefab;

    public float bulletSpeed = 10f;
    public float newShootingDelay = 0.5f;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.transform.position);

        if (distanceToPlayer <= shootingRange && canShoot)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, shootingRange);
            bool hasEnemiesInRange = false;

            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.CompareTag("Enemy"))
                {
                    hasEnemiesInRange = true;
                    break;
                }
            }

            if (!hasEnemiesInRange)
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity, enemySpawner.transform);
            }

            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        Vector3 direction = (playerTarget.transform.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        yield return new WaitForSeconds(newShootingDelay);

        canShoot = true;
    }
}
