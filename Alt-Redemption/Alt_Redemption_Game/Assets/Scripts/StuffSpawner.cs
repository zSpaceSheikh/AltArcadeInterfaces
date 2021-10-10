using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour
{

    public GameObject can;
    public GameObject garbo;
    public GameObject longBoi;

    public float spawnTimer;

    private bool gameIsPlaying = true;
    
    void Start()
    {
        StartCoroutine(spawnStuff());
    }

    IEnumerator spawnStuff()
    {
        while (gameIsPlaying)
        {
            yield return new WaitForSeconds(spawnTimer);
        
            int choice = Random.Range(0, 3);
        
            if (choice == 0)
            {
                spawnCompost();
            }
            else if (choice == 1)
            {
                spawnTrash();
            }
            else
            {
                spawnRecycle();
            }   
        }
        
    }

    private void spawnCompost()
    {
        int aT = Random.Range(1, 89);
        GameObject c = Instantiate(longBoi) as GameObject;
        c.transform.position = new Vector3(0f, 6f, -1.25f);
        c.transform.Rotate(0, 0, aT);
        
    }
    private void spawnTrash()
    {
        int aT = Random.Range(1, 89);
        GameObject t = Instantiate(garbo) as GameObject;
        t.transform.position = new Vector3(0f, 6f, -1.25f);
        t.transform.Rotate(0, 0, aT);
    }
    private void spawnRecycle()
    {
        int aR = Random.Range(1, 89);
        GameObject r = Instantiate(can) as GameObject;
        r.transform.position = new Vector3(0f, 6f, -1.25f);
        r.transform.Rotate(0, 0, aR);
    }
    
}
