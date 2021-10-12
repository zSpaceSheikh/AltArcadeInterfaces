using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public bool isOrder1;
    public bool isOrder2;
    
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ingredient"))
        {
            Debug.Log(collision.gameObject.tag);
            Destroy(collision.gameObject);
        }
        
    }
}
