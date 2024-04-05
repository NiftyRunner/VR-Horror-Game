using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHandler : MonoBehaviour
{
    public int pCount = 0;


    public bool isPuzzleGameComplete = false;
    bool isKeySpawned = false;

    [SerializeField] GameObject closeChest;
    [SerializeField] GameObject openChest;
    [SerializeField] ObjectiveManager manager;
    [SerializeField] GameObject jumpScareTrigger;

    void Start()
    {
        isPuzzleGameComplete = false;
        closeChest.SetActive(true);
        openChest.SetActive(false);
    }

    private void Update()
    {
        if(pCount == 3)
        {
            SpawnKey();
            jumpScareTrigger.SetActive(true);
        }
        if (isPuzzleGameComplete)
        {
            //Debug.Log("Updated");
            //isPuzzleGameComplete = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        
    }

    void SpawnKey()
    {
        if(!isKeySpawned) 
        {
            openChest.SetActive(true);
            closeChest.SetActive(false);
            Debug.Log("Key Spawned");
            isPuzzleGameComplete = true;
            isKeySpawned = true;
        }
    }
}
