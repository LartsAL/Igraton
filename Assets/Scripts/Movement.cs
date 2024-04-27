using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float jumpStrength = 3f;
    
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private float _inputX;
    private bool _jumpButtonPressed;
    private bool _isGrounded;
    private bool _isGoingToLand;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        _inputX = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpButtonPressed = true;
        }

        if (_inputX == 0)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
            if (_inputX > 0)
            {
                spriteRenderer.flipX = false;
            }
            if (_inputX < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
    }

    private void FixedUpdate()
    {
        Walk();
        Jump();
    }

    private void Walk()
    {
        rb.velocity = new Vector2(_inputX * movementSpeed, rb.velocity.y);
    }
    
    void Jump()
    {
        if (_jumpButtonPressed && _isGrounded)
        {
            animator.SetTrigger("isJumping");
            _isGoingToLand = true;
            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            _jumpButtonPressed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isGoingToLand)
        {
            animator.SetTrigger("isLanding");
            _isGoingToLand = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        GroundUpdate(other, true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GroundUpdate(other, false);
    }

    private void GroundUpdate(Collider2D other, bool state)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = state;
        }
    }
}
