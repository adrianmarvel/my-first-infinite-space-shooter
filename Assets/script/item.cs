using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public Sprite[] spritItem = new Sprite[3];
    public bool shield;
    public bool health;
    public bool bullet;
    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        if(shield == true)
        {
            rend.sprite = spritItem[0];
        } else if (health == true)
        {
            rend.sprite = spritItem[1];
        }else if (bullet == true)
        {
            rend.sprite = spritItem[2];
        }
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = Quaternion.Euler(90,0,180);
    }

     void OnTriggerEnter(Collider hitInfo) {
        playerShield _shield = hitInfo.GetComponent<playerShield>();
        player _player = hitInfo.GetComponent<player>();
        if(shield == true && _shield !=null)
        {
            _shield.health = 100;
            Destroy(gameObject,0.0f);
        }
        if(health == true && _player !=null)
        {
            if(_player.health <= 80)
            {
                _player.health += 20;
                Destroy(gameObject,0.0f);
            } else if (_player.health > 81)
            {
                _player.health = 100;
                Destroy(gameObject,0.0f);
            }
            
        }
        if(bullet == true && _player !=null)
        {
            _player.blueBulletCount = 100;
            Destroy(gameObject,0.0f);
        }
    }
}
