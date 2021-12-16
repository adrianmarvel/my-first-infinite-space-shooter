using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIntance : MonoBehaviour
{
    public GameObject spawner;
    public GameObject enemyPrefab;
    private enemySpawner EnemySpawner;
    public float counter;
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawner = spawner.GetComponent<enemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(EnemySpawner.phase == 8)
        {
            counter = counter + Time.deltaTime;
            if(counter >= Random.Range(0.9f,1.0f))
            {
                transform.position = new Vector3(Random.Range(-3.9f,3.9f),0,7.16f);
                Instantiate(enemyPrefab, transform.position, transform.rotation);
                counter = 0;
            }
        }
    }
}
