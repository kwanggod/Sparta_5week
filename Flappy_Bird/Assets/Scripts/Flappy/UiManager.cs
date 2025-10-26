using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI restartTxt;
    // Start is called before the first frame update
    void Start()
    {
        restartTxt.gameObject.SetActive(false);
    }
    public void SetRestart()
    {
        restartTxt.gameObject.SetActive(true);
    }
    public void UpdateScore(int score)
    {
        scoreTxt.text = score.ToString();
    }
}
