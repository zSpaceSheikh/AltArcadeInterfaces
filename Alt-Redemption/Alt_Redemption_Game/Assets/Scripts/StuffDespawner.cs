using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffDespawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("Ingredient"))
        {
            Debug.Log(collision.gameObject.tag);
           Destroy(collision.gameObject);
        }
        
    }
}
