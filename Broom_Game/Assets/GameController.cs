using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;

     void Start()
    {
        ShootingEnemyBasic shootingEnemy = FindObjectOfType<ShootingEnemyBasic>();
        shootingEnemy.playerTarget = player;
    }
}
