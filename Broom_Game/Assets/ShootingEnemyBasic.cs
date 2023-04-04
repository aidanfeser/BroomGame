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

   
    
    void Update()
    {
        
        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.transform.position);

       
        if (distanceToPlayer <= shootingRange && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

       
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        
        Vector3 direction = (playerTarget.transform.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 7f;

        
        yield return new WaitForSeconds(shootingDelay);

        canShoot = true;
    }
}
