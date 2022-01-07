using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Difficulty : MonoBehaviour
{
    public int difficulty;
    public ammo enemyDamage;
    //public enemy enemy2;
    public TextMeshProUGUI diff;
    // Start is called before the first frame update
    void Awake()
    {
        difficulty = PlayerPrefs.GetInt("Difficulty");
        diff.text = PlayerPrefs.GetInt("Difficulty").ToString();

        switch(PlayerPrefs.GetInt("Difficulty"))
        {
            case 0:
            enemyDamage.enemyDamage = 3;
                break;
            case 1:
            enemyDamage.enemyDamage = 5;
                break;
            case 2:
            enemyDamage.enemyDamage = 7;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
