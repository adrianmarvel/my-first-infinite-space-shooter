﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform rightWeapon;
    public Transform leftWeapon;
    public GameObject jetStream1;
    public GameObject jetStream2;
    public Rigidbody peluru;
    public float fireRate;
    public GameObject enemyExplosion;
    public int health;
    private bool allowFire = true;
    private float rand;
    private player _player;
    private GameObject player_;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomNumb",1,0.1f);
        player_ = GameObject.Find("Player");
        _player = player_.GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {

        jetStream1.transform.localScale = new Vector3(3,rand,3);
        jetStream2.transform.localScale = new Vector3(3,rand,3);

        if(health <= 0)
        {
            death();
            _player.score = _player.score + 100;
        }

        if(allowFire==true)
        {
            fire(rightWeapon);
            fire(leftWeapon);
        }
    }
    void RandomNumb()
    {
        rand = Random.Range(3f,4f);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void fire(Transform weapon)
    {
        Rigidbody ammoInstance;
        ammoInstance = Instantiate(peluru, weapon.position, weapon.rotation) as Rigidbody;
        ammoInstance.AddForce(weapon.up * 800f);

        delay();
    }

    void death()
    {
        Instantiate(enemyExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    void delay()
    {
        allowFire = false;
        Invoke("delay1",fireRate);
    }
    void delay1()
    {
        allowFire = true;
    }

    void OnTriggerEnter(Collider collision)
    {
        player _player = collision.GetComponent<player>();
        if (collision.gameObject.name == "Player")
        {
            health = 0;
            _player.TakeDamage(50);
        }
    }
}
