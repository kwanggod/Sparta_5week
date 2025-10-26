using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 1f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathcooldown = 0f;
    bool start;

    bool isFlap = false;

    public bool godMode = false;

    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        start = false;
    }


    void Update()
    {
        if (!start)
        {
            gameManager.PauseGame();
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                start = true;
                gameManager.ResumeGame();
            }
        }

        if (isDead)
            {
                if (deathcooldown <= 0)
                {
                    if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
                    {
                        gameManager.RestartGame();
                    }
                }
                else
                {
                    deathcooldown -= Time.deltaTime;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
                {
                    isFlap = true;
                }
            }
        
    }
    private void FixedUpdate()
    {
        if (isDead)
            return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y*5f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode)
            return;

        if (isDead)
            return;

        isDead = true;
        deathcooldown = 1f;
        animator.SetInteger("IsDie", 1);
        gameManager.GameOver();
    }

}
