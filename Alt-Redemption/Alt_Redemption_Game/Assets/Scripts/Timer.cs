using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLength;
    private float currentTime;

    private TextMeshProUGUI countdownText;
    
    void Start()
    {
        countdownText = FindObjectOfType<TextMeshProUGUI>();
        countdownText.text = "";
        
        currentTime = timeLength;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
    }
}
