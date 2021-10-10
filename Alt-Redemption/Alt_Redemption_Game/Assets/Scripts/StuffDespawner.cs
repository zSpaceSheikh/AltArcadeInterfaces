using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffDespawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        
        Debug.Log(collision.gameObject.tag);
        Destroy(collision.gameObject);
        
        
        //if (collision.gameObject.CompareTag("Compost"))
        //{
        //    Debug.Log(collision.gameObject.tag);
        //   Destroy(collision.gameObject);
        //}
        
    }
}
