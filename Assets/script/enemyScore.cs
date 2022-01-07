using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScore : MonoBehaviour
{
    public int killScore;
    private enemy health;
    private GameObject player_;
    public player _player;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
