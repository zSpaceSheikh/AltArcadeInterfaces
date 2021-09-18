using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = -5f;
    private Vector2 startPos;
    
    void Start()
    {
        startPos = transform.position;
    }
    
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, 15);
        transform.position = startPos + Vector2.up * newPos;
    }
}
