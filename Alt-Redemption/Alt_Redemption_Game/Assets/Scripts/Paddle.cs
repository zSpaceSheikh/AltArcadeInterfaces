using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;


public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public float speed;
    public Rigidbody rigiB;

    private float movement;


    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        //Debug.Log(movement*speed);
        rigiB.velocity = new Vector3(movement * speed, 0, 0);
    }
}
