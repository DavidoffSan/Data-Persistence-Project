using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public InputField nameInputField;

    public void OnStartButtonClick()
    {
        string playername = nameInputField.text;
        PlayerPrefs.SetString("PlayerName", playername );
        SceneManager.LoadScene("main");
    }
}
