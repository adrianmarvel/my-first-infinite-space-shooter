using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighscoreClass{
    
    public int score;

    public HighscoreClass (Highscore highscore)
    {
        score = highscore.score;
    }

}
