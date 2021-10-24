using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public bool isOrder1;
    public bool isOrder2;
    
    public static Score S;
    
    private void Awake()
    {
        if (S == null)
        {
            S = this;
        }
    }
    
    
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Checking order...");
        
        if (collision.gameObject.CompareTag("Bins"))
        {
            //Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
        
    }
}
