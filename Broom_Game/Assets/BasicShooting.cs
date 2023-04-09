using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    public bool canShoot;

    void Start()
    {
        canShoot = true;
    }

    private void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            if(canShoot == true)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                Vector2 forward = firePoint.TransformDirection(Vector2.up);
                rb.velocity = forward * bulletSpeed;
            }
           
            
        }
    }
}
