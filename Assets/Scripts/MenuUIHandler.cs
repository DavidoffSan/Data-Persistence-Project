using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInput;
    [SerializeField] private TMP_Text bestScoreText;

    private void Start()
    {
        // Load the best score and player name from GameManager
        bestScoreText.text = $"Best Score = {GameManager.instance.bestPlayerName} : {GameManager.instance.bestScore}";
    }
    public void StartGame()
    {
        GameManager.instance.currentPlayerName = playerNameInput.text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit(); // original code to quit Unity player
#endif
    }
}

