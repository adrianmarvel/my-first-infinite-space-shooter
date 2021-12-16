using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public int health;
    public float speed = 10f;
    public Joystick joystick1;
    public float smooth = 5f;
    public GameObject jetStream1;
    public GameObject jetStream2;
    public Text ScoreUI;
    //public Text score;
    private float rand;

    Vector3 velocity;
    
    private CharacterController controller;
    private Rigidbody rb;

    public Rigidbody peluru;
    public Rigidbody blueAmmo;
    public Transform rightWeapon;
    public Transform leftWeapon;
    public Transform[] weapons;
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
        shield.transform.rotation = Quaternion.Slerp(shield.transform.rotation, Quaternion.Euler(90, x, 0),  Time.deltaTime * smooth);

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
        }

        if(x != 0 && z != 0 && allowFire == true)
        {
            switch(weaponStates)
            {
                case 1:
                    fire(rightWeapon, peluru);
                    fire(leftWeapon, peluru);
                    break;
                case 2:
                    fire(weapons[0], blueAmmo);
                    fire(weapons[1], blueAmmo);
                    fire(weapons[2], blueAmmo);
                    break;
            }
        }

        ScoreUI.text = "Score : " + score;

        if(shieldScript.health <=0)
        {
            shieldCol.enabled = false;
            shieldScript.enabled = false;
            shield.SetActive(false);
        }
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
