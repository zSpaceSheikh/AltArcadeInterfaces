using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Orders : MonoBehaviour
{
    public GameObject receipt;
    public GameObject orderText;
    
    private TextAsset ordersTxt;
    private string[] ordersList;
    private Text order_display;
    public string orderName;

    public bool newOrder = true;
    private bool firstOrder = true;

    public bool atPointB = false;
    
    // receipt start and end points
    private Vector3 pointAReceipt = new Vector3(-4.6f, -5.85f, -3f);
    private Vector3 pointBReceipt = new Vector3(-4.6f, -1.25f, -3f);
    // order text start and end points
    private Vector3 pointAText = new Vector3(-274f, -116f, -247f);
    private Vector3 pointBText = new Vector3(-274f, 308, -247f);

    public float receiptSpeed = 3f;
    
    private float t;
    
    public static Orders S;
    
    private void Awake()
    {
        if (S == null)
        {
            S = this;
        }
    }
    
    
    void Start()
    {
        order_display = GetComponentInChildren<Text>();
        order_display.text = "";
        StartCoroutine(GetTextFromFile());
    }

    IEnumerator GetTextFromFile()
    {
        ordersTxt = Resources.Load("orders") as TextAsset;
        ordersList = ordersTxt.text.Split('\n');
        
        yield return null;
    }

    void Update()
    {
        // always start out by giving the player a very basic order 
        if (firstOrder && newOrder)
        {
            FirstOrder();
            firstOrder = false;
            newOrder = false;
            
            StartCoroutine(MoveReceipt());
        }

        // if the player needs the next order, spawn a new order
        if (newOrder)
        {
            NewOrder();
            newOrder = false;
            StartCoroutine(MoveReceipt());
        }
        else
        {
            // maybe check for new ingredients to check off from the list?
        }
        
    }


    void FirstOrder()
    {
        // grab the first order
        string[] fullOrder = ordersList[0].Split('=');
        
        // display the order name on the receipt
        orderName = fullOrder[0];
        OrderName.S.SetText();
        
        // display the ingredients on the receipt
        string order = fullOrder[1].Replace("+", "\n");
        order_display.text = order;
        
        // play intro audio clip
        
    }

    void NewOrder()
    {
        // choose a random order
        int r = Random.Range(1, ordersList.Length);
        string[] fullOrder = ordersList[r].Split('=');
        
        // display the order name on the receipt
        orderName = fullOrder[0];
        OrderName.S.SetText();
        
        // display the ingredients on the receipt
        string order = fullOrder[1].Replace("+", "\n");
        order_display.text = order;
        
        // play associated audio clip
        
    }

    IEnumerator MoveReceipt()
    {
        // receipt print sound
        AudioManager.S.ReceiptPrint();
        
        receipt.transform.position = pointAReceipt;
        orderText.transform.localPosition = pointAText;
        t = 0;
        
        while (atPointB == false)
        {
            // wait a little bit so the receipt moves in steps
            yield return new WaitForSeconds(0.1f);
           //t += Time.deltaTime;
           t += 0.05f;
            
            // find the amount to move the receipt and text
            Vector3 pos = Vector3.Lerp(pointAReceipt, pointBReceipt, t);
            Vector3 posT = Vector3.Lerp(pointAText, pointBText, t);
            
            //Debug.Log(receipt.transform.position.y);
            
            // move the receipt
            receipt.transform.position = pos;
            orderText.transform.localPosition = posT;

            if (receipt.transform.position.y >= pointBReceipt.y)
            {
                atPointB = true;
            }
        }
        atPointB = false;
        yield return null;
    }
}
