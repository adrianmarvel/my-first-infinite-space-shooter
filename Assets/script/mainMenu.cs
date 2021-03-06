using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public int speed;
    public AudioSource buttonPress;
    public AudioSource backsound;
    public Animator anim;
    public Animator anim1;
    public int difficulty = 1;
    public Slider music;
    public Slider sfx;
    public float musicVolume;
    public float sfxVolume;
    public int killScore = 200;
    public RectTransform selector;
    public RectTransform[] selection = new RectTransform[3];
    // Start is called before the first frame update
    void Start()
    {
        backsound.volume = PlayerPrefs.GetFloat("MusicVolume");
        buttonPress.volume = PlayerPrefs.GetFloat("SfxVolume");
        music.value = PlayerPrefs.GetFloat("MusicVolume");
        sfx.value = PlayerPrefs.GetFloat("SfxVolume");
        difficulty = PlayerPrefs.GetInt("Difficulty");

        switch(difficulty)
        {
            case 0:
                selector.transform.position = selection[0].transform.position;
                break;
            case 1:
                selector.transform.position = selection[1].transform.position;
                break;
            case 2:
                selector.transform.position = selection[2].transform.position;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(-1,0,0) * speed * Time.deltaTime);
        backsound.volume = music.value;
        buttonPress.volume = sfx.value;

        musicVolume = music.value;
        sfxVolume = sfx.value;

        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SfxVolume", sfxVolume);
        PlayerPrefs.SetInt("Difficulty", difficulty);
        PlayerPrefs.SetInt("KillScore", killScore);
    }

    public void buttonStart()
    {
        buttonPress.Play();
        anim.Play("start");
        Invoke("start", 0.5f);
    }

    public void start()
    {
        SceneManager.LoadScene(1);
    }
    public void buttonExit()
    {
        buttonPress.Play();
        anim.Play("exit");
        Invoke("Exit", 0.5f);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void buttonOptions()
    {
        anim.Play("options");
        buttonPress.Play();
        Invoke("options", 0.5f);
    }
    public void options()
    {
        anim1.Play("main menu to options");
        anim.Play("New State");
    }
    public void buttonBack()
    {
        buttonPress.Play();
        anim1.Play("options to main menu");
    }

    public void buttonCredits()
    {
        anim.Play("credits");
        buttonPress.Play();
        Invoke("credits", 0.5f);
    }

    public void creditstomenu()
    {
        anim1.Play("credit to main menu");
        buttonPress.Play();
    }

    public void credits()
    {
        anim1.Play("main menu to credits");
        anim.Play("New State");
    }

    public void easy()
    {
        difficulty = 0;
        selector.transform.position = selection[0].transform.position;
        killScore = 100;
    }
    public void medium()
    {
        difficulty = 1;
        selector.transform.position = selection[1].transform.position;
        killScore = 200;
    }
    public void hard()
    {
        difficulty = 2;
        selector.transform.position = selection[2].transform.position;
        killScore = 300;
    }
}
