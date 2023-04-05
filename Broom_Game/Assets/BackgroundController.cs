using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Transform player;
    public float speed = 0.1f;
    public float wrapWidth = 20f;

    private Vector3 offset;
    private Vector3 prevPlayerPos;

    void Start()
    {
        offset = transform.position - player.position;
        prevPlayerPos = player.position;
    }

    void LateUpdate()
    {
        Vector3 playerMovement = player.position - prevPlayerPos;
        transform.position -= playerMovement * speed;
        prevPlayerPos = player.position;

        // Wrap the background around when it goes beyond the bounds of the screen
        if (transform.position.x - player.position.x < -wrapWidth)
        {
            transform.position += new Vector3(wrapWidth * 2f, 0f, 0f);
        }
        else if (transform.position.x - player.position.x > wrapWidth)
        {
            transform.position -= new Vector3(wrapWidth * 2f, 0f, 0f);
        }
        if (transform.position.y - player.position.y < -wrapWidth)
        {
            transform.position += new Vector3(0f, wrapWidth * 2f, 0f);
        }
        else if (transform.position.y - player.position.y > wrapWidth)
        {
            transform.position -= new Vector3(0f, wrapWidth * 2f, 0f);
        }
    }
}

