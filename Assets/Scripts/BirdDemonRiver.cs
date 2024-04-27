using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDemonRiver : MonoBehaviour
{
    public Vector2 returnPos;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BirdDemon"))
        {
            other.transform.position = returnPos;
        }
    }
}
