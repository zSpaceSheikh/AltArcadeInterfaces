using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        actions.Add("Welcome to plinko burger, home of the plinko burger, can I take your order?", GameStart);
        actions.Add("game start", GameStart);
        
        
        // voice recognition stuff
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void GameStart()
    {
        SceneManager.LoadScene("PlinkoBurgerSingleOrder");
    }
    
    private void RecognizedSpeech(PhraseRecognizedEventArgs Speech)
    {
        //Debug.Log(Speech.text);
        actions[Speech.text].Invoke();
    }
}
