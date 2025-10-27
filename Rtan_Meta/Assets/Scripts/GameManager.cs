using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set; }
    public UiManager uiManager { get; private set; }
    public MainUiManager mainUiManager { get; private set; }
    public int currentScore = 0;
    public int highScore=0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
    }

    public void RegisterUI(UiManager ui)
    {
        uiManager = ui;

    }
    public void RegisterMainUI(MainUiManager mainUi)
    {
        mainUiManager = mainUi;
    }

    public void GameOver()
    {
        uiManager.SetRestart();
        uiManager.HighScore(highScore);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void AddSocre(int score)
    {
        currentScore += score;
        if (highScore < currentScore)
            highScore = currentScore;
        uiManager.UpdateScore(currentScore);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
