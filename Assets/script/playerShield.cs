using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShield : MonoBehaviour
{
    public Color[] shieldColor = new Color[2];
    public Color myColor;
    public Material shieldMaterial;
    public GameObject shield;
    private SphereCollider col;
    public AudioClip[] clip = new AudioClip[2];
    private AudioSource audioSource;
    public int health;
    public int smooth = 10;
    public float a = 2;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = shield.GetComponent<AudioSource>();
        myColor = shieldColor[0];
    }

    // Update is called once per frame
    void Update()
    {
        a = a + Time.deltaTime * smooth;
        if(a >= 5f)
        {
            a = 5f;
        }
        shieldMaterial.SetFloat("Vector1_B39CF12D", a);
        if(health <=0)
        {
            
        }

        if(health <= 30)
        {
            myColor = Color.Lerp(myColor, shieldColor[1], Time.deltaTime * smooth);
            shieldMaterial.SetColor ("Color_A8AFA9E1", myColor);
        } else if(health >= 50){
            myColor = Color.Lerp(myColor, shieldColor[0], Time.deltaTime * smooth);
            shieldMaterial.SetColor ("Color_A8AFA9E1", myColor);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        a = 2f;
    }
}
