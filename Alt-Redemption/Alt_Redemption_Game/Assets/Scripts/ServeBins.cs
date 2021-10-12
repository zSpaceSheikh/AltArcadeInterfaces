using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeBins : MonoBehaviour
{
    public GameObject bin1;
    public GameObject bin2;
    
    public GameObject order1Floor;
    public GameObject order2Floor;

    public float moveDelay;

    private bool serve1 = true;
    private bool serve2 = true;

    public float binSpeed;
    private Vector3 targetPos1 = new Vector3(6f, -4.82f, -0.97f);
    private Vector3 targetPos2 = new Vector3(-6f, -4.82f, -0.97f);
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && serve1)
        {
            GameObject b1 = Instantiate(bin1) as GameObject;
            b1.transform.position = new Vector3(-1.95f, -4.82f, -0.97f);
            
            order1Floor.SetActive(false);
            
            serve1 = false;
            StartCoroutine(SendOrder1(b1));
        }
        if (Input.GetKeyDown(KeyCode.RightShift) && serve2)
        {
            GameObject b2 = Instantiate(bin2) as GameObject;
            b2.transform.position = new Vector3(1.95f, -4.82f, -0.97f);
            
            order2Floor.SetActive(false);
            
            serve2 = false;
            StartCoroutine(SendOrder2(b2));
        }
    }

    IEnumerator SendOrder1(GameObject b)
    {
        WaitForSeconds delay = new WaitForSeconds(moveDelay);

        yield return delay;
        
        order1Floor.SetActive(true);
        
        
        while (b.transform.position.x > -6f)
        {
            Vector3 pos = Vector3.MoveTowards(b.transform.position, targetPos2, binSpeed * Time.deltaTime);
            b.GetComponent<Rigidbody>().MovePosition(pos);
            
            yield return null;
        }
        
        Destroy(b);
        
        serve1 = true;
    }
    
    IEnumerator SendOrder2(GameObject b)
    {
        WaitForSeconds delay = new WaitForSeconds(moveDelay);

        yield return delay;
        
        order2Floor.SetActive(true);
        
        
        while (b.transform.position.x < 6f)
        {
            Vector3 pos = Vector3.MoveTowards(b.transform.position, targetPos1, binSpeed * Time.deltaTime);
            b.GetComponent<Rigidbody>().MovePosition(pos);
            
            yield return null;
        }
        
        Destroy(b);

        serve2 = true;
    }
    
}