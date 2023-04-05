using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerRanged : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 5f;
    public float spawnRange = 10f;
    public float speed = 3f;

    public Transform[] spawnPoints;

    public GameObject player;
    public Transform playerTrans;
    //public Transform bulletSpawn;
    public GameObject bulletPref;

    private bool canSpawn = true;

   

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }


    IEnumerator SpawnEnemies()
    {
        while (canSpawn)
        {
            // Wait for a random delay between minSpawnDelay and maxSpawnDelay
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));

            Vector3 spawnPosition = new Vector3(Random.Range(2f, -2f), Random.Range(2f, -2f), 0);
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Vector2 spawnPositionarea = spawnPoints[spawnIndex].position;
           //GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            Quaternion spawnRotation = Quaternion.identity;
            GameObject enemy = Instantiate(enemyPrefab, spawnPositionarea, spawnRotation);

            ShootingEnemyBasic enemyController = enemy.AddComponent<ShootingEnemyBasic>();
            enemyController.playerTarget = player;
            enemyController.bulletPrefab = bulletPref;
            //enemyController.bulletSpawnPoint = bulletSpawn;

            // Instantiate the bullet spawn point transform from the prefab
            Transform bulletSpawnPrefab = enemyPrefab.GetComponent<ShootingEnemyBasic>().bulletSpawnPoint;
            // Instantiate the bullet spawn point transform in the scene
            Transform bulletSpawnScene = Instantiate(bulletSpawnPrefab, enemy.transform);

            // Set the bullet spawn point to the instantiated transform in the scene
            enemyController.bulletSpawnPoint = bulletSpawnScene;

            EnemyController2D enemyControllerScript = enemy.AddComponent<EnemyController2D>();
            enemyControllerScript.target = playerTrans;
            enemyControllerScript.speed = speed;
        }
    }
}

