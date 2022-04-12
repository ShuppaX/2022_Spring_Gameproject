using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area3Spawning : MonoBehaviour
{
    // define the delivery guy objects
    [SerializeField] private GameObject delivererRoute1;
    [SerializeField] private GameObject delivererRoute2;
    [SerializeField] private GameObject delivererRoute3;

    // A GameObject that is used to clone the original deliverer
    private GameObject spawnedDeliverer;

    // Initializing a list for deliverers
    private List<GameObject> deliverers = new List<GameObject>();
    
    private ScoreManager scoreManagerBlue;

    private int logisticsCap = 6;
    
    private void Awake()
    {
        scoreManagerBlue = FindObjectOfType<ScoreManager>();
        scoreManagerBlue.BlueScore3 = logisticsCap;
    }

    // spawn deliverers
    public void Spawn()
    {
        if (scoreManagerBlue.BlueScore3 > 0)
        {
            // set and spawn spawnedDeliverer as a clone of deliverer
            // also track deliverers by amount to define which deliverer is used
            // (used to have more routes)
            if (scoreManagerBlue.BlueScore3 > 4)
            {
                spawnedDeliverer = Instantiate(delivererRoute1, transform.position, Quaternion.identity);
            }
            else if (scoreManagerBlue.BlueScore3 > 2)
            {
                spawnedDeliverer = Instantiate(delivererRoute2, transform.position, Quaternion.identity);
            }
            else if (scoreManagerBlue.BlueScore3 > 0)
            {
                spawnedDeliverer = Instantiate(delivererRoute3, transform.position, Quaternion.identity);
            }
        
            // add the spawnedDeliverer to the list initialized earlier
            deliverers.Add(spawnedDeliverer);
        
            // set the deliverer active
            deliverers[deliverers.Count - 1].SetActive(true);
        
            // add logistics score by one to track deliverers on the UI
            scoreManagerBlue.BlueScore3--;
        }
    }
    
    // despawn the last deliverer that was spawned
    public void DespawnLast()
    {
        // Check if lists index value is below zero, if yes then return
        // otherwise destroy the last object in the list
        if (deliverers.Count - 1 < 0)
        {
            return;
        }

        if (scoreManagerBlue.BlueScore3 < logisticsCap)
        {
            Destroy(deliverers[deliverers.Count - 1]);
            deliverers.RemoveAt(deliverers.Count - 1);
            spawnedDeliverer = null;
            
            // reduce logistics score to track the amount of deliverers on the UI
            scoreManagerBlue.BlueScore3++;
        }
    }
}
