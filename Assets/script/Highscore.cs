using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    public int score;
    public int currentHighscore;
    public GameObject player;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreOnGameOver;
    public TextMeshProUGUI yourScore;
    public player playerScipt;

    void Start()
    {
        LoadHighscore();

        scoreText.text = "Highscore : " + currentHighscore;
    }

    void Update()
    {
        score = playerScipt.score;

        if(playerScipt.health == 0)
        {
            if(score >= currentHighscore)
            {
                saveData();
            }
        }
        if(score < currentHighscore)
        {
            yourScore.text = "your score : " + score;
            highscoreOnGameOver.text = "highscore : " + currentHighscore;
        }else if (score >= currentHighscore)
        {
            highscoreOnGameOver.enabled = false;
            yourScore.text = "your new highscore : " + score;
        }
    }

    public void saveData()
    {
        SaveSystem.SaveHighscore(this);
    }
    public void LoadHighscore()
    {
        HighscoreClass data = SaveSystem.LoadHighscore();
        currentHighscore = data.score;
    }
}
