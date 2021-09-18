using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource playerHit;

    public static AudioManager S;

    private void Awake()
    {
        if (S == null)
        {
            S = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    PlayerHitSound();
        //}
    }

    public void PlayerHitSound()
    {
        playerHit.Play();
    }
    
}
