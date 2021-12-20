using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public RectTransform[] status = new RectTransform[2];
    public int health;
    public float speed = 10f;
    public Joystick joystick1;
    public float smooth = 5f;
    public GameObject jetStream1;
    public GameObject jetStream2;
    public Text ScoreUI;
    //public Text score;
    private float rand;    
    private CharacterController controller;
    private Rigidbody rb;

    public Rigidbody peluru;
    public Rigidbody blueAmmo;
    public Transform rightWeapon;
    public Transform leftWeapon;
    public Transform[] weapons;
    public AudioClip[] weaponSounds;
    private AudioSource audioSource;
    public int weaponStates = 1;
    public GameObject shield;
    private SphereCollider shieldCol;
    private playerShield shieldScript;
    public float fireRate;
    private bool allowFire = true;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody>();
        controller = gameObject.GetComponent<CharacterController>();
        shieldCol = GetComponent<SphereCollider>();
        shieldScript = GetComponent<playerShield>();

        InvokeRepeating("RandomNumb",1,0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        float x = joystick1.Horizontal;
        float z = joystick1.Vertical;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move (move *speed * Time.deltaTime);

        Quaternion target = Quaternion.Euler(0, 0, -x*50);
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        
        transform.position = new Vector3(transform.position.x,0,transform.position.z);

        jetStream1.transform.localScale = new Vector3(3,z*5,3);
        jetStream2.transform.localScale = new Vector3(3,z*5,3);

        if(z <= 0.2)
        {
            jetStream1.transform.localScale = new Vector3(3,rand,3);
            jetStream2.transform.localScale = new Vector3(3,rand,3);
        }

        if(Input.GetKeyDown("1"))
        {
            weaponStates = 1;
        } else if(Input.GetKeyDown("2"))
        {
            weaponStates = 2;
        } else if(Input.GetKeyDown("3"))
        {
            weaponStates = 3;
        }else if(Input.GetKeyDown("4"))
        {
            shieldScript.health = 100;
        }

        if(x != 0 && z != 0 && allowFire == true)
        {
            switch(weaponStates)
            {
                case 1:
                    fire(rightWeapon, peluru);
                    fire(leftWeapon, peluru);
                    audioSource.clip = weaponSounds[0];
                    audioSource.Play();
                    break;
                case 2:
                    fire(weapons[0], blueAmmo);
                    fire(weapons[1], blueAmmo);
                    fire(weapons[2], blueAmmo);
                    audioSource.clip = weaponSounds[1];
                    audioSource.Play();
                    break;
                case 3:
                    fire(rightWeapon, peluru);
                    fire(leftWeapon, peluru);
                    fire(weapons[0], blueAmmo);
                    fire(weapons[1], blueAmmo);
                    fire(weapons[2], blueAmmo);
                    audioSource.clip = weaponSounds[1];
                    audioSource.Play();
                    break;
            }
        }

        ScoreUI.text = "Score : " + score;

        if(shieldScript.health <=0)
        {
            shieldCol.enabled = false;
            //shieldScript.enabled = false;
            shield.transform.localScale = Vector3.Lerp(shield.transform.localScale, new Vector3(0.5f,0.5f,0.5f), Time.deltaTime * 5);
        } else if (shieldScript.health >= 0)
        {
            shieldCol.enabled = true;
            shield.transform.localScale = Vector3.Lerp(shield.transform.localScale, new Vector3(3f,3f,3f), Time.deltaTime * 5);            
        }

        status[0].sizeDelta = new Vector2(health, 10);
        status[1].sizeDelta = new Vector2(shieldScript.health, 10);
    }

    void RandomNumb()
    {
        rand = Random.Range(0.9f,1.5f);
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void fire(Transform weapon, Rigidbody ammo)
    {
        Rigidbody ammoInstance;
        ammoInstance = Instantiate(ammo, weapon.position, weapon.rotation) as Rigidbody;
        ammoInstance.AddForce(weapon.up * 1000f);
           
        delay();
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
}
