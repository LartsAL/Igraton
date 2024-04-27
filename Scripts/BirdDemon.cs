using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDemon : MonoBehaviour
{
    public float speed = 4.0f;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        int flipped = spriteRenderer.flipX ? -1 : 1;
        rb.velocity = new Vector2(speed * flipped, 0);
    }
}
