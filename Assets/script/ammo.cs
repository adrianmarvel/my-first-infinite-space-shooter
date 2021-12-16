using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{   
    public int playerDamage;
    public int enemyDamage;
    public GameObject explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    void OnTriggerEnter(Collider hitInfo) {
        enemy _enemy = hitInfo.GetComponent<enemy>();
        if (_enemy != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            _enemy.TakeDamage(playerDamage);
            Destroy (gameObject);
        }
        /*player _player = hitInfo.GetComponent<player>();
        if (_player != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            _player.TakeDamage(enemyDamage);
            Destroy (gameObject);
        }*/
        playerShield _shield = hitInfo.GetComponent<playerShield>();
        if(_shield != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            _shield.TakeDamage(enemyDamage);
            Destroy (gameObject);
            if(_shield.health <= 0)
            {
                player _player = hitInfo.GetComponent<player>();
                if (_player != null)
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                    _player.TakeDamage(enemyDamage);
                    Destroy (gameObject);
                }
            }
        }
    }
}
