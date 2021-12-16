using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShield : MonoBehaviour
{
    public GameObject shield;
    private SpriteRenderer sprite;
    private SphereCollider col;
    public int health;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        sprite = shield.GetComponent<SpriteRenderer>();
        col = shield.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite.color = Vector4.Lerp(sprite.color, new Color(255,255,255,0), Time.deltaTime * speed);
        if(health <=0)
        {
            
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        sprite.color = new Color(255,255,255,255);
    }
}
