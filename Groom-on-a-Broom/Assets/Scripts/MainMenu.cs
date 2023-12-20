using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButton() {
        GameManager.totalLife = 1; // better way to reset total life?
        Time.timeScale = 1f; // how to remove?
        SceneManager.LoadScene(1);
    }
    public void OnQuitButton()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
