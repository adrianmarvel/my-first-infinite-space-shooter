using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgExtender : MonoBehaviour
{
    public Rigidbody background;
    public Transform instantiator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Instantiate(background, instantiator.position, instantiator.rotation);
        //Debug.Log("Collided");
    }
}
