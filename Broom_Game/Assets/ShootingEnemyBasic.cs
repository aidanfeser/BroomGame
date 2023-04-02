using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyBasic : MonoBehaviour
{
    public GameObject playerTarget;   // a reference to the player object
    public float shootingRange = 10f;   // the distance at which the enemy will start shooting
    public float shootingDelay = 1f;    // the delay between shots
    public GameObject bulletPrefab;     // a reference to the bullet object that will be fired
    public Transform bulletSpawnPoint;  // the point where the bullet will be spawned
    
    private bool canShoot = true;   // a flag to prevent the enemy from shooting too often

   
    // Update is called once per frame
    void Update()
    {
        // calculate the distance between the player and the enemy
        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.transform.position);

        // if the player is within shooting range, and the enemy can shoot, then shoot
        if (distanceToPlayer <= shootingRange && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        // spawn a new bullet object at the bullet spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // set the bullet's direction to be towards the player
        Vector3 direction = (playerTarget.transform.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 10f;

        // wait for the shooting delay before allowing the enemy to shoot again
        yield return new WaitForSeconds(shootingDelay);

        canShoot = true;
    }
}
