using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Windows.Speech;
using System.Linq;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    public bool autoSpawn;
    public float lightUpTime;
    public float spawnTimer;

    public GameObject orderFloor;
    
    // ingredient hoppers
    [Header("Ingredient Hoppers")] 
    public GameObject hopBun;
    public GameObject hopBurger;
    public GameObject hopTomato;
    public GameObject hopLettuce;
    public GameObject hopCheese;
    public GameObject hopBacon;
    
    // ingredient prefabs
    [Header("Ingredient Prefabs")] 
    public GameObject bunTop;
    public GameObject burg;
    public GameObject tomato;
    public GameObject bacon;
    public GameObject lettuce;
    public GameObject cheese;
    public GameObject bunBot;
    
    // mesh renderer variables
    private MeshRenderer bunMR;
    private MeshRenderer baconMR;
    private MeshRenderer lettuceMR;
    private MeshRenderer burgerMR;
    private MeshRenderer tomatoMR;
    private MeshRenderer cheeseMR;

    private bool gameIsPlaying = true;

    private int ingredientChoice = 0;
    
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    
    
    void Start()
    {
        if (autoSpawn)
        {
            StartCoroutine(spawnIngredients());
        }
        
        actions.Add("burger", Burger);
        actions.Add("buns", Buns);
        actions.Add("bacon", Bacon);
        actions.Add("lettuce", Lettuce);
        actions.Add("tomato", Tomato);
        actions.Add("cheese", Cheese);
        
        // voice recognition stuff
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
        
        
        // emission material stuff
        bunMR = hopBun.GetComponent<MeshRenderer>();
        baconMR = hopBacon.GetComponent<MeshRenderer>();
        tomatoMR = hopTomato.GetComponent<MeshRenderer>();
        burgerMR = hopBurger.GetComponent<MeshRenderer>();
        lettuceMR = hopLettuce.GetComponent<MeshRenderer>();
        cheeseMR = hopCheese.GetComponent<MeshRenderer>();
        
}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            orderFloor.SetActive(false);
            Invoke("RemoveFloor", 2f);
        }
    }
    
    private void RemoveFloor()
    {
        orderFloor.SetActive(true);
    }


    private void RecognizedSpeech(PhraseRecognizedEventArgs Speech)
    {
     
        Debug.Log(Speech.text);
        actions[Speech.text].Invoke();
    }
    
    
    private void Burger()
    {
        Debug.Log("spawn burger!");
        spawnIngredient(burg, hopBurger);
        
        // light up the burger bin
        burgerMR.material.EnableKeyword("_EMISSION");
        Invoke("BurgerLightUp", lightUpTime);
    }
    
    private void Bacon()
    {
        Debug.Log("spawn bacon!");
        spawnIngredient(bacon, hopBacon);
        
        // light up the bacon bin
        baconMR.material.EnableKeyword("_EMISSION");
        Invoke("BaconLightUp", lightUpTime);
    }
    
    private void Lettuce()
    {
        Debug.Log("spawn lettuce!");
        spawnIngredient(lettuce, hopLettuce);
        
        // light up the lettuce bin
        lettuceMR.material.EnableKeyword("_EMISSION");
        Invoke("LettuceLightUp", lightUpTime);
    }
    
    private void Buns()
    {
        Debug.Log("spawn buns!");
        spawnIngredient(bunTop, hopBun);
        spawnIngredient(bunBot, hopBun);
        
        // light up the bun bin
        bunMR.material.EnableKeyword("_EMISSION");
        Invoke("BunLightUp", lightUpTime);
    }
    
    private void Cheese()
    {
        Debug.Log("spawn cheese!");
        spawnIngredient(cheese, hopCheese);
        
        // light up the cheese bin
        cheeseMR.material.EnableKeyword("_EMISSION");
        Invoke("CheeseLightUp", lightUpTime);
    }
    
    private void Tomato()
    {
        Debug.Log("spawn tomato!");
        spawnIngredient(tomato, hopTomato);
        
        // light up the tomato bin
        tomatoMR.material.EnableKeyword("_EMISSION");
        Invoke("TomatoLightUp", lightUpTime);
    }

    
    
    private void spawnIngredient(GameObject ingredient, GameObject hopper)
    {
        // give the spawned item a random rotation
        int aI = Random.Range(1, 89);
        
        // add a clone of the item to the scene at the correct position
        GameObject c = Instantiate(ingredient) as GameObject;
        Vector3 hopperLoc = hopper.transform.position;
        c.transform.position = new Vector3(hopperLoc.x, hopperLoc.y, -1.25f);
        c.transform.Rotate(0, 0, aI);
        
        // activate the spawn sound
        AudioManager.S.SpawnDing();
    }
    
    
    IEnumerator spawnIngredients()
    {
        while (gameIsPlaying)
        {
            yield return new WaitForSeconds(spawnTimer);
        
            
            // spawn buns
            if (ingredientChoice == 0)
            {
                Buns();
                ingredientChoice += 1;
            }
            // spawn a burger
            else if (ingredientChoice == 1)
            {
                Burger();
                ingredientChoice += 1;
            }
            // spawn a tomato
            else if (ingredientChoice == 2)
            {
                Tomato();
                ingredientChoice += 1;
            }
            // spawn a bacon
            else if (ingredientChoice == 3)
            {
                Bacon();
                ingredientChoice += 1;
            }
            // spawn a lettuce
            else if (ingredientChoice == 4)
            {
                Lettuce();
                ingredientChoice += 1;
            }
            // spawn cheese
            else
            {
                Cheese();
                ingredientChoice = 0;
            }
               
        }
        
    }
    
    private void BunLightUp()
    {
        bunMR.material.DisableKeyword("_EMISSION");
    }
    
    private void BurgerLightUp()
    {
        burgerMR.material.DisableKeyword("_EMISSION");
    }
    
    private void TomatoLightUp()
    {
        tomatoMR.material.DisableKeyword("_EMISSION");
    }
    
    private void BaconLightUp()
    {
        baconMR.material.DisableKeyword("_EMISSION");
    }
    
    private void LettuceLightUp()
    {
        lettuceMR.material.DisableKeyword("_EMISSION");
    }
    
    private void CheeseLightUp()
    {
        cheeseMR.material.DisableKeyword("_EMISSION");
    }
}
