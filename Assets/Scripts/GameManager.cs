using System;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int bestScore;
    public int currentScore;
    public string bestPlayerName;
    public string currentPlayerName;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string PlayerName;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();

        bestPlayerName = currentPlayerName;
        bestScore = currentScore;

        data.HighScore = bestScore;
        data.PlayerName = bestPlayerName;

        string json = JsonUtility.ToJson(data);

        Debug.Log("Persistent data path = " + Application.persistentDataPath);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            Debug.Log("Persistent data path = " + path);
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.HighScore;
            bestPlayerName = data.PlayerName;
        }
        else
        {
            bestScore = 0;
            bestPlayerName = "Nobody";
        }
    }

}

