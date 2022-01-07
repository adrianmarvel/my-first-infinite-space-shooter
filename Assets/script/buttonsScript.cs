using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonsScript : MonoBehaviour
{
    public GameObject pauseState;
    public enemy enemy1;
    public enemy enemy2;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pause()
    {
        pauseState.SetActive(true);
        Time.timeScale = 0f;
    }
    public void resume()
    {
        pauseState.SetActive(false);
        Time.timeScale = 1f;
    }
    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
        enemy1.maxRand = 3;
        enemy2.maxRand = 3;
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        enemy1.maxRand = 3;
        enemy2.maxRand = 3;
    }
    public void exit()
    {
        Application.Quit();
        enemy1.maxRand = 3;
        enemy2.maxRand = 3;
    }
}
