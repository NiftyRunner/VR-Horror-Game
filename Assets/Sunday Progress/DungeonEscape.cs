using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DungeonEscape : TaskBaseState
{
    bool isDungeonComplete;
    DungeonHandler dungeonHandler;

    GameObject dungeonTextParent;
    TextMeshProUGUI dungeonText;
    
    GameObject dungeonObject;

    public override void EnterState(ObjectiveManager manager)
    {
        Debug.Log("dungeon State");

        manager.dungeonGate1.transform.rotation = Quaternion.Euler(0, 90, 120);
        manager.dungeonGate2.transform.rotation = Quaternion.Euler(0, 90, -120);

        dungeonTextParent = GameObject.FindGameObjectWithTag("DungeonStateText");
        dungeonText = dungeonTextParent.GetComponent<TextMeshProUGUI>();
        dungeonText.enabled = true;

        dungeonObject = GameObject.FindGameObjectWithTag("DungeonState");
        dungeonHandler = dungeonObject.GetComponent<DungeonHandler>();
        isDungeonComplete = false;
    }

    public override void UpdateState(ObjectiveManager manager)
    {
        isDungeonComplete = dungeonHandler.isDungeonGameComplete;
        if (isDungeonComplete)
        {
            dungeonText.enabled = true;
            manager.SwitchState(State.Default);
        }
    }

    public override void OnTriggerExit(ObjectiveManager manager, Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
        }
    }
}
