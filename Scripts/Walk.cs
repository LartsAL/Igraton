using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Walk : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform transform;

    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rigidbody;

    private float PassedTime = 0f;

    public Vector2 StartPoint;

    public float speedX = 1;
    public float speedY = 1;
    
    public float moveY = 1;
    

    void Start()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        transform.Translate(StartPoint);
        rigidbody.velocity = new Vector2(speedX, speedY);
    }



    void Update()
    {
        Debug.Log(PsycheBar.count);
    }

    private void FixedUpdate()
    {

        // transform.Translate(new Vector2(1f * speedX, 1f * speedY) * Time.fixedDeltaTime);
        Debug.Log(PsycheBar.count);
        PassedTime += Time.fixedDeltaTime;
        if (PassedTime > 3f)
        {
            StartPoint.y += moveY;
            PassedTime = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTrigger()");
        if (other.tag == "RiverLoop")
        {
            Debug.Log("OnTrigger() In");
            transform.position = StartPoint;
           // transform.Translate(StartPoint);
            Debug.Log("OnTrigger() Out");
        }
    }

}

