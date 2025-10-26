using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    private int currentScore = 0;

    UiManager uiManager;
    public UiManager UiManager { get { return uiManager; } }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UiManager>();
    }
    private void Start()
    {
        uiManager.UpdateScore(0);
    }
    public void GameOver()
    {
        uiManager.SetRestart();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AddSocre(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
    }
}
