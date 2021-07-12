using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistanceManager : MonoBehaviour
{
    public static PersistanceManager instance;

    public string playerName;
    public int playerScore;
    public int highScore=0;
    public string highScorePlayerName="";
    

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void CheckHighScore()
    {
        if (playerScore > highScore)
        {
            highScore = playerScore;
            highScorePlayerName = playerName;
        }

    }
}
