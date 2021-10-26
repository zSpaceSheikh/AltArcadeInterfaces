using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    
    public AudioSource spawnDing;
    public AudioSource receiptPrint;
    public AudioSource registerOrder;

    public AudioSource[] orderVoices;
    
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
    
    public void ReceiptPrint()
         {
             receiptPrint.Play();
         }
    
    public void RegisterSound()
    {
        registerOrder.Play();
    }
}
