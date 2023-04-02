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


