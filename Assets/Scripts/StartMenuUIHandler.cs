using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;

    public void StartGame()
    {
        DataPersistenceManager.Instance.playerName = nameInputField.text;
        SceneManager.LoadScene("main");
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}

