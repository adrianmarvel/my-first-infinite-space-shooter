using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanceEnemyMovement : MonoBehaviour
{
    public int speed;
    private Rigidbody enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody>();

        enemy.AddForce(transform.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
