using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float dashDistance = 5f; // distance to dash
    [SerializeField] private float dashSpeed = 10f; // speed of dash
    [SerializeField] private float dashCoolDown = 2f;

    public TrailRenderer tr;
    private bool canDash = true;
    private Vector3 dashDirection;

    public GameObject Panal;
   
    public int currentExp = 0;
    public int maxExp;

    public bool Level1;
    public bool Level2 = false;
    public bool Level3 = false;
    // int exp = player.currentExp;


    BasicShooting shootingScript;

    void Start()
    {
        maxExp = 10;
        Level1 = true;

        shootingScript = GetComponent<BasicShooting>();
    }
    private void Update()

    {
        if (Input.GetMouseButtonDown(1) && canDash)
        {
            // get the direction towards the mouse cursor
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dashDirection = transform.position - mousePosition;
            dashDirection.z = 0f;
            dashDirection.Normalize();

            // start dashing
            canDash = false;
            StartCoroutine(Dash());
            StartCoroutine(DashCooldown());
        }

        if(currentExp == maxExp)
        {
            
            LevelUp();
        }

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Drop"))
        {
            // Check if the other collider is the circle collider
            CircleCollider2D circleCollider = other.GetComponentInChildren<CircleCollider2D>();
            if (circleCollider != null)
            {
                currentExp += 1;

                Destroy(other.gameObject);
            }
        }
    }
    void LevelUp()
    {
        Panal.SetActive(true);
        currentExp = 0;

        if(Level1 == true)
        {
            Level1 = false;
            Level2 = true;
            
            Time.timeScale = 0f;

            shootingScript.canShoot = false;

            maxExp = 50;

            PlayerHealth playerHealth = GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.currentHealth = playerHealth.startHealth;
            }


        }
    }
    private IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }
    private IEnumerator Dash()
    {
        float distanceTraveled = 0f;

        while (distanceTraveled < dashDistance)
        {
            float distanceThisFrame = dashSpeed * Time.deltaTime;
            transform.position += dashDirection * distanceThisFrame;
            distanceTraveled += distanceThisFrame;
            tr.emitting = true;
            yield return null;
            tr.emitting = false;
        }
    }
}


