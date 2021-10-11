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

    // ingredient hoppers
    [Header("Ingredient Hoppers")] 
    public GameObject hopBun;
    public GameObject hopBurger;
    public GameObject hopTomato;
    public GameObject hopLettuce;
    public GameObject hopCheese;
    public GameObject hopBacon;
    public GameObject hopMystery;
    
    // ingredient prefabs
    [Header("Ingredient Prefabs")] 
    public GameObject bunTop;
    public GameObject burg;
    public GameObject tomato;
    public GameObject bacon;
    public GameObject lettuce;
    public GameObject cheese;
    public GameObject bunBot;
    
    [Header("Mystery Prefabs")] 
    public GameObject apple;
    public GameObject banana;
    public GameObject blueberry;
    
    // add more game object calls to model prefabs here -----------------------------------------
    
    // mesh renderer variables
    private MeshRenderer bunMR;
    private MeshRenderer baconMR;
    private MeshRenderer lettuceMR;
    private MeshRenderer burgerMR;
    private MeshRenderer tomatoMR;
    private MeshRenderer cheeseMR;
    private MeshRenderer mysteryMR;

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

        // calls to main ingredients for voice recognition
        actions.Add("burger", Burger);
        actions.Add("buns", Buns);
        actions.Add("bacon", Bacon);
        actions.Add("lettuce", Lettuce);
        actions.Add("tomato", Tomato);
        actions.Add("cheese", Cheese);

        // calls to mystery ingredients for voice recognition
        actions.Add("apple", Apple);
        actions.Add("banana", Banana);
        actions.Add("blueberry", Blueberry);
        actions.Add("blueberries", Blueberry);

        // add more things to spawn here ------------------------

        // voice recognition stuff
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();


        // hopper emission material stuff
        bunMR = hopBun.GetComponent<MeshRenderer>();
        baconMR = hopBacon.GetComponent<MeshRenderer>();
        tomatoMR = hopTomato.GetComponent<MeshRenderer>();
        burgerMR = hopBurger.GetComponent<MeshRenderer>();
        lettuceMR = hopLettuce.GetComponent<MeshRenderer>();
        cheeseMR = hopCheese.GetComponent<MeshRenderer>();
        mysteryMR = hopMystery.GetComponent<MeshRenderer>();
    }


    private void RecognizedSpeech(PhraseRecognizedEventArgs Speech)
    {
     
        Debug.Log(Speech.text);
        actions[Speech.text].Invoke();
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
    
    // mystery food spawn functions
    private void Apple()
    {
        Debug.Log("spawn apple!");
        spawnIngredient(apple, hopMystery);
        
        // light up the mystery bin
        mysteryMR.material.EnableKeyword("_EMISSION");
        Invoke("MysteryLightUp", lightUpTime);
    }
    
    private void Banana()
    {
        Debug.Log("spawn banana!");
        spawnIngredient(banana, hopMystery);
        
        // light up the mystery bin
        mysteryMR.material.EnableKeyword("_EMISSION");
        Invoke("MysteryLightUp", lightUpTime);
    }
    
    private void Blueberry()
    {
        Debug.Log("spawn blueberries!");
        for (int i = 0; i < 15; i++) {
            spawnIngredient(blueberry, hopMystery);
        }

        // light up the mystery bin
        mysteryMR.material.EnableKeyword("_EMISSION");
        Invoke("MysteryLightUp", lightUpTime);
    }

    // add more stuff spawning functions here -----------------------------------------
    
    
    // for auto spawning ingredients
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
    
    // hopper disable glow functions
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
    
    private void MysteryLightUp()
    {
        mysteryMR.material.DisableKeyword("_EMISSION");
    }
}
