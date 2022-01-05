using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public GameObject enemyObject;
    public GameObject spawner;
    public GameObject enemyBullet;
    private enemy enemyScript;
    private instanceEnemyMovement enemyMovement;
    private EnemyIntance enemySpawner;
    private ammo enemyBulletScript;
    public int health;
    public int enemyDamage;
    public int speed;
    public float timeSpawn;
    // Start is called before the first frame update
    void Awake()
    {
        enemyScript = enemyObject.GetComponent<enemy>();
        enemyMovement = enemyObject.GetComponent<instanceEnemyMovement>();
        enemySpawner = spawner.GetComponent<EnemyIntance>();
        enemyBulletScript = enemyBullet.GetComponent<ammo>();

        health = enemyScript.health;
        enemyDamage = enemyBulletScript.enemyDamage;
        speed = enemyMovement.speed;
        timeSpawn = enemySpawner.timeSpawn;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
