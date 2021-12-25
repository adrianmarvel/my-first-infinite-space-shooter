using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyExposion : MonoBehaviour
{
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x,0.5f,gameObject.transform.position.z);
    }
}
