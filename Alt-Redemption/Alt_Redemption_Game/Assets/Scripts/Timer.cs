using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.ProBuilder;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLength;
    private float currentTime;

    public TextMeshProUGUI countdownText;
    
    void Start()
    {
        //countdownText = FindObjectOfType<TextMeshProUGUI>();
        countdownText.text = "";
        
        currentTime = timeLength;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
        }
        else
        {
            currentTime = 0;
            GameEnd();
        }
        //countdownText.text = currentTime.ToString("0");
        
        DiplayTime(currentTime);
    }

    void DiplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float mins = Mathf.FloorToInt(timeToDisplay / 60);
        float secs = Mathf.FloorToInt(timeToDisplay % 60);
        
        countdownText.text = string.Format("{0:00}:{1:00}", mins, secs);
    }
    
    private void GameEnd()
    {
        SceneManager.LoadScene("EndScene");
    }
    
}
