using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WitchObjectCollection : TaskBaseState
{
    GameObject collectionTextParent;
    TextMeshProUGUI collectionText;
    GameObject witchGameObject;
    CollectionHandler triggerScript;
    bool isTaskComplete;

    //public bool isObjectSpawned = false;

    public override void EnterState(ObjectiveManager manager)
    {
        //isObjectSpawned = true;

        collectionTextParent = GameObject.FindGameObjectWithTag("CollectionTaskText");
        collectionText = collectionTextParent.GetComponent<TextMeshProUGUI>();
        collectionText.enabled = true; //Activates the text of objective.

        witchGameObject = GameObject.FindGameObjectWithTag("CollectionTask");
        triggerScript = witchGameObject.GetComponentInChildren<CollectionHandler>();
        manager.objectCollectionObjects.SetActive(true);
        
        Debug.Log("Instantiated Objetcs");
        isTaskComplete = false;
    }

    public override void UpdateState(ObjectiveManager manager)
    {
        triggerScript = witchGameObject.GetComponentInChildren<CollectionHandler>();
        isTaskComplete = triggerScript.isCollectionComplete;
        if (isTaskComplete)
        {
            //isObjectSpawned = false;
            Debug.Log("TaskComplete");
            collectionText.enabled = false;
            manager.SwitchState(State.Default);
        }
    }

    public override void OnTriggerExit(ObjectiveManager manager, Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
        }
    }
}
