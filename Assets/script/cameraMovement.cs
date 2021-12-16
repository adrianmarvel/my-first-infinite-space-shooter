using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,0,-1) * Time.deltaTime * speed);
        Destroy(gameObject,10f);
    }

    /* private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);    
    }*/
}
