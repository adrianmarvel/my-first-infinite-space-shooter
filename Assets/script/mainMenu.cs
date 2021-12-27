using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(-1,0,0) * speed * Time.deltaTime);
    }

    public void buttonStart()
    {
        SceneManager.LoadScene(1);
    }
    public void buttonExit()
    {
        Application.Quit();
    }
}
