using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VamprireGirl : MonoBehaviour
{
    public float disappearSpeed = 0.02f;
    public float cameraSpeed = 3f;

    public GameObject player;
    public GameObject mainCamera;
    public GameObject text;
    public TextMeshProUGUI textBox;
    public SpriteRenderer spriteRenderer;

    private bool _triggered = false;
    private bool _unlocked = false;
    private bool _startedDisappearing = false;
    private bool _moveCamera;

    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //text = GameObject.Find("VampireGirlTextBox");
    }

    void Update()
    {
        if (_triggered && _unlocked && Input.GetAxis("Horizontal") != 0)
        {
            _triggered = false;
            _startedDisappearing = true;
        }
    }

    void FixedUpdate()
    {
        if (_startedDisappearing && spriteRenderer.color.a != 0)
        {
            Color color = spriteRenderer.color;
            color = new Color(color.r, color.g, color.b, color.a - disappearSpeed);
            spriteRenderer.color = color;
            textBox.color = color;
        }

        if (_moveCamera)
        {
            Vector3 pos = player.transform.position;
            mainCamera.transform.position = new Vector3(pos.x, pos.y, -10);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_startedDisappearing)
        {
            text.SetActive(true);
            _triggered = true;
            
            mainCamera.transform.SetParent(player.transform);
            _moveCamera = true;
            
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(2);
        _unlocked = true;
    }
}
