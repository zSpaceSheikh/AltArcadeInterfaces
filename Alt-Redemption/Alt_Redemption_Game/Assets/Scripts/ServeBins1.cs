using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Windows.Speech;
using System.Linq;

public class ServeBins1 : MonoBehaviour
{
    public GameObject bin1;
    
    public GameObject order1Floor;

    public float moveDelay;

    private bool serve1 = true;

    public float binSpeed;
    private Vector3 targetPos1 = new Vector3(4.5f, -4.82f, -0.97f);
    
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    private void Start()
    {
        actions.Add("order up", Order1Check);
        
        // voice recognition stuff
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && serve1)
        {
            GameObject b1 = Instantiate(bin1) as GameObject;
            b1.transform.position = new Vector3(0f, -4.82f, -0.97f);
            
            order1Floor.SetActive(false);
            
            serve1 = false;
            StartCoroutine(SendOrder1(b1));
        }
    }

    private void Order1Check()
    {
        if (serve1)
        {
            GameObject b1 = Instantiate(bin1) as GameObject;
            b1.transform.position = new Vector3(0f, -4.82f, -0.97f);
            
            order1Floor.SetActive(false);
            
            // activate register sound 
            AudioManager.S.RegisterSound();
            
            serve1 = false;
            StartCoroutine(SendOrder1(b1));
        }
    }

    IEnumerator SendOrder1(GameObject b)
    {
        //Debug.Log("Entered SendOrder1");
        WaitForSeconds delay = new WaitForSeconds(moveDelay);

        yield return delay;
        
        order1Floor.SetActive(true);
        
        bool sent1 = false;
        
        while (sent1 == false)
        {
            //Debug.Log("Moving Order 1 Bin");
            Vector3 pos = Vector3.MoveTowards(b.transform.position, targetPos1, binSpeed * Time.deltaTime);
            b.GetComponent<Rigidbody>().MovePosition(pos);
            
            if (pos.x >= 4.5f)
            {
                //Debug.Log("bin 1 arrived!");
                sent1 = true;
                Score.S.readyToCheck = true;
            }
            
            yield return null;
        }
        //Debug.Log("Destroy Order 1 Bin");
        
        Destroy(b);
        
        serve1 = true;
        Orders.S.newOrder = true;
    }
    
    private void RecognizedSpeech(PhraseRecognizedEventArgs Speech)
    {
        //Debug.Log(Speech.text);
        actions[Speech.text].Invoke();
    }
    
}
