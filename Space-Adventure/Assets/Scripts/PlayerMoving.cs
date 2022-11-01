﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    Rigidbody2D rgbdy2d;
    Animator animator;

    Vector2 velocity;
    Vector2 scale;

    float moveInput;

    [SerializeField]
    float speed = default;
    
    [SerializeField]
    float acceleration = default;

    [SerializeField]
    float slowdown= default;

    [SerializeField]
    float jumpPower = default;

    [SerializeField]
    int jumpLimit = 3;

    int splashAmount;


    void Start()
    {
        rgbdy2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        KeyboardControl();
    }

    void KeyboardControl()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        scale = transform.localScale;
        if (moveInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.4f;
        }
        else if (moveInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.4f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, slowdown * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);

        if (Input.GetKeyDown("space"))
        {
            StartJump();
        }
        if (Input.GetKeyUp("space"))
        {
            StopJump();
        }
    }

    void StartJump()
    {
        if (splashAmount<jumpLimit)
        {
            rgbdy2d.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
        }
        
    }
    void StopJump()
    {
        animator.SetBool("Jump", false);
        splashAmount++;
    }

    public void JumpReset()
    {
        splashAmount = 0;
    }

}