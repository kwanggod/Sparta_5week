using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Main_UiManager : MonoBehaviour
{
    public TextMeshProUGUI FlappyTxt;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.RegisterMainUI(this);
        FlappyTxt.gameObject.SetActive(false);
    }
    public void Flappy()
    {
        FlappyTxt.text = $"Flappy_Bird\n\n\nBestScore : {GameManager.instance.highScore}\n\n\n\n\n\n\nStart : (E)";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FlappyTxt.gameObject.SetActive(true);
            Flappy();
            Debug.Log("µé¾î¿È");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        FlappyTxt.gameObject.SetActive(false);
    }
}
