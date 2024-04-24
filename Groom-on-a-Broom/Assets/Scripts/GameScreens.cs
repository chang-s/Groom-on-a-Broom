using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreens : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverUI;

    public static bool isPaused = false;
    public static bool gameHasEnded = false;

    public TextMeshProUGUI distanceCounter;
    public TextMeshProUGUI coinCounter;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            if (isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        } else if (GameManager.totalLife < 1 && !gameHasEnded)
        {
            GameOver();
        }
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        OnExit();
    }


    public void LoadMenu()
    {
        OnExit();
        SceneManager.LoadScene(0);
    }

    private void OnExit()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game...");
    }

    public void GameOver()
    {
        isPaused = true;
        gameHasEnded = true;
        distanceCounter.text = GameManager.totalDistance.ToString();
        coinCounter.text = GameManager.totalCoins.ToString();
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
