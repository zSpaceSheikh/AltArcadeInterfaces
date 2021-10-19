using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orders : MonoBehaviour
{

    private TextAsset ordersTxt;
    private string[] ordersList;
    
    
    void Start()
    {
        StartCoroutine(GetTextFromFile());
    }

    IEnumerator GetTextFromFile()
    {
        ordersTxt = Resources.Load("orders") as TextAsset;
        ordersList = ordersTxt.text.Split('*');
        
        yield return null;
    }

}
