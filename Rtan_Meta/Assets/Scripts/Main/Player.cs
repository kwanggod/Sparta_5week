using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animator animator;
    SpriteRenderer spriteRenderer;
    int Speed;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        Speed = 2;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            animator.SetInteger("IsDirection", 2);
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            animator.SetInteger("IsDirection", 2);
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            animator.SetInteger("IsDirection", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            animator.SetInteger("IsDirection", 0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
            Speed = Speed * 2;

        dir.Normalize();

        GetComponent<Rigidbody2D>().velocity = Speed * dir;
        animator.SetBool("IsMove", dir.magnitude > 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stair"))
        {
            if (gameObject.layer == 21)
            {
                gameObject.layer = 22;
                spriteRenderer.sortingLayerName = "Layer 3";
                Debug.Log("3Ãþ µµÂø");
            }
            else if (gameObject.layer == 22)
            {
                gameObject.layer = 21;
                spriteRenderer.sortingLayerName = "Layer 2";
                Debug.Log("2Ãþ µµÂø");
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Potal") && Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("Flappy_Bird");
        }
    }
}