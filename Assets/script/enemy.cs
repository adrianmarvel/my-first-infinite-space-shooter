using System.Collections;
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
    public int item;
    public Rigidbody itemInstance;
    public GameObject itemGameObject;
    private item itemScript;
    private AudioSource audioSource;
    public int killScore;

    void Awake()
    {
        killScore = PlayerPrefs.GetInt("KillScore");
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("RandomNumb",1,0.1f);
        player_ = GameObject.Find("Player");
        _player = player_.GetComponent<player>();

        itemScript = itemGameObject.GetComponent<item>();
    }

    // Update is called once per frame
    void Update()
    {

        jetStream1.transform.localScale = new Vector3(3,rand,3);
        jetStream2.transform.localScale = new Vector3(3,rand,3);

        if(health <= 0)
        {
            death();
            itemDrop();
        }

        if(allowFire==true)
        {
            fire(rightWeapon);
            fire(leftWeapon);
            audioSource.Play();
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
        _player.score += killScore;
        Instantiate(enemyExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    void itemDrop()
    {
        Rigidbody itemInstancee;

        itemInstancee = Instantiate(itemInstance, transform.position, Quaternion.Euler(90,0,180)) as Rigidbody;
        itemInstancee.AddForce(transform.up * 100f);
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

    void OnTriggerEnter(Collider hitInfo)
    {
        player _player = hitInfo.GetComponent<player>();
        playerShield _shield = hitInfo.GetComponent<playerShield>();
        if (hitInfo.gameObject.name == "Player")
        {
            _shield.health -= 20;
            health = 0;
            if(_shield.health<=0)
            {
                _player.TakeDamage(20);
            }
        }
    }
}
