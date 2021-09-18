﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Ball : MonoBehaviour
{
    public float ballSpeed;
    public Rigidbody2D rb;
    public Vector3 startPosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        Launch();
    }
    
    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }
    
    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(ballSpeed * x, ballSpeed * y);
    }
}
