using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public Transform player;

    public float initialSpawnDelay = 2f;
    public float enemySpeed = 3f;

    private float spawnTimer = 0f;
    private float currentSpawnDelay;

    PlayerMovement playerScript;

    private void Start()
    {
        currentSpawnDelay = initialSpawnDelay;
        playerScript = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= currentSpawnDelay)
        {
            spawnTimer = 0f;
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Vector2 spawnPosition = spawnPoints[spawnIndex].position;
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Attach the EnemyController script to the new enemy
            EnemyController2D enemyController = newEnemy.AddComponent<EnemyController2D>();
            enemyController.target = player;
            enemyController.speed = enemySpeed;

            // Decrease the spawn delay over time
            currentSpawnDelay -= 0.1f * Time.deltaTime;
            currentSpawnDelay = Mathf.Clamp(currentSpawnDelay, 0.5f, initialSpawnDelay);
        }
        if(playerScript.Level2 == true)
        {
            initialSpawnDelay = 1f;
        }

    }
}


