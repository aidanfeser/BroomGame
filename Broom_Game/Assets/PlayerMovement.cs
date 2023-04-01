using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float dashDistance = 1f; // The distance the player will dash
    public float dashTime = 0.2f; // The duration of the dash animation
    public KeyCode dashKey = KeyCode.Mouse1; // The key used to trigger the dash

    private Vector3 dashDirection = Vector3.zero; // The direction the player will dash in
    private bool isDashing = false; // Whether or not the player is currently dashing

    void Update()
    {
        // Get the direction from the player to the mouse cursor
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Make sure the z-coordinate is the same as the player's
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Check if the player has clicked the dash key and isn't already dashing
        if (Input.GetKeyDown(dashKey) && !isDashing)
        {
            // Set the dash direction to the opposite of the cursor direction
            dashDirection = -direction;

            // Start the dash animation coroutine
            StartCoroutine(DashAnimation());
        }
    }

    IEnumerator DashAnimation()
    {
        isDashing = true; // Set the dashing flag

        // Calculate the destination position for the dash
        Vector3 destination = transform.position + dashDirection * dashDistance;

        // Move the player to the destination position over the duration of the dash animation
        float elapsedTime = 0f;
        while (elapsedTime < dashTime)
        {
            transform.position = Vector3.Lerp(transform.position, destination, elapsedTime / dashTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset the player's position and dashing flag
        transform.position = destination;
        isDashing = false;
    }
}


