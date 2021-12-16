using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorSpawner : MonoBehaviour
{
    public Sprite[] meteorSprites;
    public GameObject meteorPrefab;
    public Rigidbody meteorRigidbody;
    private SpriteRenderer prefabSprite;
    public float counter;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        prefabSprite = meteorPrefab.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        counter = counter + Time.deltaTime;
        if(counter >= Random.Range(10.0f,12.0f))
        {
            prefabSprite.sprite = meteorSprites[Random.Range(0,8)];
            transform.position = new Vector3(Random.Range(-3.9f,3.9f),Random.Range(-1.0f,-2.0f),10.0f);

            Rigidbody meteor;
            meteor = Instantiate(meteorRigidbody, transform.position, transform.rotation) as Rigidbody;
            meteor.AddForce(-transform.up * speed);
            meteor.MoveRotation(meteor.rotation * Quaternion.Euler(new Vector3(0,0,Random.Range(-100,100)) * 100));
            meteor.gameObject.transform.localScale *= Random.Range(0.1f,1.5f);

            speed = Random.Range(20,30);
            counter = 0;
        }
    }
}
