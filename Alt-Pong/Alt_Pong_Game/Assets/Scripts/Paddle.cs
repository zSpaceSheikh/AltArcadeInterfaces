using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public float speed;
    public float speedBoost;
    public Rigidbody2D rb;
    public Vector3 startPosition;

    private float movement;
    
    private Animator animator;

    void Awake()
    {
        // ...
        animator = GetComponent<Animator>();
        //...
    }

    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Player 1 movement input
        if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, movement * speed);

            // Animate player 1 if they are moving up the screen
            if (movement > 0)
            {
                animator.SetBool("IsBiking", true);
            }
            else
            {
                animator.SetBool("IsBiking", false);
            }
        }
        
        // Player 2 movement input
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
            
            // Animate player 2 if they are moving up the screen
            if (movement > 0)
            {
                animator.SetBool("IsBiking", true);
            }
            else
            {
                animator.SetBool("IsBiking", false);
            }
            
            // check for speed boost button
            if (Input.GetButtonDown("Boost2"))
            {
                rb.velocity = new Vector2(rb.velocity.x, movement * speedBoost);
            }

            else
            {
                rb.velocity = new Vector2(rb.velocity.x, movement * speed);
            }
        }
        
        //rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}