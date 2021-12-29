using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIntance : MonoBehaviour
{
    public GameObject spawner;
    public GameObject enemyPrefab;
    private enemySpawner EnemySpawner;
    public float counter;
    public float timeSpawn = 2.0f;
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
            if(counter >= Random.Range(timeSpawn, timeSpawn+0.1f))
            {
                transform.position = new Vector3(Random.Range(-3.9f,3.9f),0,7.16f);
                Instantiate(enemyPrefab, transform.position, transform.rotation);
                counter = 0;
            }
        }
    }
}
