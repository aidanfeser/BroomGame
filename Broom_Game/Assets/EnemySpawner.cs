using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public Transform player;

    public float spawnDelay = 2f;
    public float enemySpeed = 3f;

    private float spawnTimer = 0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnDelay)
        {
            spawnTimer = 0f;
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Vector2 spawnPosition = spawnPoints[spawnIndex].position;
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Attach the EnemyController script to the new enemy
            EnemyController2D enemyController = newEnemy.AddComponent<EnemyController2D>();
            enemyController.target = player;
            enemyController.speed = enemySpeed;
        }
    }
}


