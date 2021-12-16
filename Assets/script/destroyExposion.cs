using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyExposion : MonoBehaviour
{
    public int time;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Destroy(gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,0.5f,gameObject.transform.position.z);
        sprite.color = Vector4.Lerp(sprite.color, new Color(0,0,0,-0), 2*Time.deltaTime);
    }
}
