using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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


    public void SaveScoreDetails()
    {

        SaveData data = new SaveData();
        data.highScore = highScore;

        data.highScorePLayerName = highScorePlayerName;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("DataSaved!");

    }

    public void LoadScoreDetails()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScorePlayerName = data.highScorePLayerName;

        }



    }
}
[System.Serializable]
class SaveData
{

    public int highScore;
    public string highScorePLayerName;
}
