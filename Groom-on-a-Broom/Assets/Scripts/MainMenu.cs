using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButton() {
        GameManager.totalLife = 5; // better way to reset total life?
        GameManager.totalCoins = 0;
        GameManager.totalDistance = 0;
        GameManager.cleared = false;
        GameScreens.gameHasEnded = false;
        Time.timeScale = 1f; // how to remove?
        SceneManager.LoadScene(1);
    }
    public void OnQuitButton()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
