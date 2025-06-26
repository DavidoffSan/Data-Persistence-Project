using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playerInfoText; // or use UnityEngine.UI.Text if not using TMP
    private int score = 0;

    //public TextMeshProUGUI highScoreText;

    void Start()
    {
        playerInfoText.text = $"High Score: {DataPersistenceManager.Instance.highScorePlayer} - {DataPersistenceManager.Instance.highScore}";
    }

    void UpdateScoreUI(string playerName)
    {
        playerInfoText.text = playerName + " - Score: " + score;
    }

    // Call this method whenever you want to increase score
    public void AddScore(int points)
    {
        score += points;
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");
        UpdateScoreUI(playerName);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void GameOver()
    {
        if (score > DataPersistenceManager.Instance.highScore)
        {
            DataPersistenceManager.Instance.highScore = score;
            DataPersistenceManager.Instance.highScorePlayer = DataPersistenceManager.Instance.playerName;
            DataPersistenceManager.Instance.SaveHighScore();
        }
    }

}
