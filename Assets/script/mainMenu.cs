using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public int speed;
    public AudioSource audioSource;
    public Animator anim;
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
        audioSource.Play();
        anim.Play("start");
        Invoke("start", 0.5f);
    }

    public void start()
    {
        SceneManager.LoadScene(1);
    }
    public void buttonExit()
    {
        audioSource.Play();
        anim.Play("exit");
        Invoke("Exit", 0.5f);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
