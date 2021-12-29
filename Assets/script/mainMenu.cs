using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public int speed;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(-1,0,0) * speed * Time.deltaTime);
    }

    public void buttonStart()
    {
        audio.enabled = true;
        SceneManager.LoadScene(1);
    }
    public void buttonExit()
    {
        audio.enabled = true;
        Application.Quit();
    }
}
