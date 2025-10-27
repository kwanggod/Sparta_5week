using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI restartTxt;
    public TextMeshProUGUI highScoreTxt;
    public Button restartButton;
    public Button ExitButton;
    // Start is called before the first frame update
    void Start()
    {
        restartTxt.gameObject.SetActive(false);
        highScoreTxt.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(false);
        GameManager.instance.RegisterUI(this);
        GameManager.instance.currentScore = 0;
    }
    public void SetRestart()
    {
        restartTxt.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        ExitButton.gameObject.SetActive(true);
        highScoreTxt.gameObject.SetActive(true);
    }
    public void UpdateScore(int score)
    {
        scoreTxt.text = score.ToString();
    }
    public void HighScore(int score)
    {
        highScoreTxt.text = "HighScore : "+score.ToString();
    }
    public void OnRestartButton()
    {
        GameManager.instance.RestartGame();
    }
    public void OnExitButton()
    {
        GameManager.instance.ExitGame();
    }
}
