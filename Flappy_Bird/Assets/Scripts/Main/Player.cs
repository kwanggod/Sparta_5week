using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    int Speed;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        Speed = 1;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
        }
        if (Input.GetKey(KeyCode.LeftShift))
            Speed = 3;

        dir.Normalize();

        GetComponent<Rigidbody2D>().velocity = Speed * dir;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Stair"))
        {
            if (gameObject.layer == 21)
            {
                gameObject.layer = 22;
                spriteRenderer.sortingLayerName = "Layer 3";
                Debug.Log("3Ãþ µµÂø");
            }
            else if(gameObject.layer == 22)
            {
                gameObject.layer = 21;
                spriteRenderer.sortingLayerName = "Layer 2";
                Debug.Log("2Ãþ µµÂø");
            }
        }
        if (other.CompareTag("Potal"))
        {
            SceneManager.LoadScene("Flappy_Bird");
        }
    }
}