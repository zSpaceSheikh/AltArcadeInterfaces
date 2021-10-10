using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    
    public AudioSource spawnDing;
    
    public static AudioManager S;

    private void Awake()
    {
        if (S == null)
        {
            S = this;
        }
    }
    
    
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    PlayerHitSound();
        //}
    }
    
    public void SpawnDing()
    {
        spawnDing.Play();
    }
}
