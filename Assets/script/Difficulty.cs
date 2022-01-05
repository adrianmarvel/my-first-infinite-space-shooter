using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Difficulty : MonoBehaviour
{
    public int difficulty;
    public ammo enemyDamage;
    public enemy _enemy;
    public enemySpawner spawner;
    public TextMeshProUGUI diff;
    // Start is called before the first frame update
    void Awake()
    {
        diff.text = difficulty.ToString();
        difficulty = PlayerPrefs.GetInt("Difficulty");
        switch(difficulty)
        {
            case 0:
                enemyDamage.enemyDamage = 3;
                _enemy.killScore = 100;
                break;
            case 1:
                enemyDamage.enemyDamage = 5;
                _enemy.killScore = 200;
                break;
            case 2:
                enemyDamage.enemyDamage = 7;
                _enemy.killScore = 300;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
