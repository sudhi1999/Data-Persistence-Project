using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_InputField playerNameIF;
    public Button startBtn;
    public Button quitBtn;
    public TMP_Text bestScoreTxt;
    

    private void Start()
    {
        PersistanceManager.instance.LoadScoreDetails();
        bestScoreTxt.text = $"Best Score : {PersistanceManager.instance.highScorePlayerName} : {PersistanceManager.instance.highScore}";

        startBtn.onClick.AddListener(() =>
        {

            if (playerNameIF.text=="")
            {
                Debug.Log("Enter Your Name To Continue");
            }
            else
            {
                PersistanceManager.instance.playerName=playerNameIF.text;

                SceneManager.LoadScene(1);

            }

        });
        quitBtn.onClick.AddListener(() =>
        {
            Application.Quit();

        });
    }

   
}
