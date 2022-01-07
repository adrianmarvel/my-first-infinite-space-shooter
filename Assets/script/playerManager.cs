using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerManager : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject[] playerAmmo;
    private ammo[] playerAmmoScript = new ammo[2];
    private player playerScript;
    private playerShield shieldScript;
    public int[] playerDamage = new int[2];
    public int playerHealth;
    public int shieldHealth;
    public float speed;
    public float fireRate;
    public GameObject enemyObject;
    public enemy enemy1;
    public GameObject explosion;
    public GameObject gameOverState;
    private Transform playerTrans;
    public GameObject enemySpawner;
    public int score;
    private EnemyIntance spawner;
    private int modulus;
    private int increase = 0;
    // Start is called before the first frame update
    void Awake()
    {
        playerScript = playerObject.GetComponent<player>();
        shieldScript = playerObject.GetComponent<playerShield>();

        playerTrans = playerObject.GetComponent<Transform>();
        spawner = enemySpawner.GetComponent<EnemyIntance>();

        playerAmmoScript[0] = playerAmmo[0].GetComponent<ammo>();
        playerAmmoScript[1] = playerAmmo[1].GetComponent<ammo>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = playerScript.health;
        shieldHealth = shieldScript.health;
        speed = playerScript.speed;
        fireRate = playerScript.fireRate;

        playerDamage[0] = playerAmmoScript[0].playerDamage;
        playerDamage[1] = playerAmmoScript[1].playerDamage;

        score = playerScript.score;

        if(playerScript.health <= 0)
        {
            Invoke("gameOver", 1);
        }
        modulus = playerScript.score%1000;
        if(spawner.timeSpawn >= 0.5f)
        {
            if(modulus==0 && increase==0)
            {
                spawner.timeSpawn -= 0.1f;
                enemy1.maxRand += 1;
                increase++;
            }else if(modulus==100)
            {
                increase = 0;
            }
        }        
    }

    void gameOver()
    {
        gameOverState.SetActive(true);
        Time.timeScale = 0f;
    }
}
