using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleRoom : TaskBaseState
{
    bool isPuzzleComplete;

    PuzzleHandler puzzleHandler;
    GameObject puzzleObject;
    GameObject puzzleTextParent;
    TextMeshProUGUI puzzleText;

    public override void EnterState(ObjectiveManager manager)
    { 
        Debug.Log("Puzzle State");

        manager.puzzleGate.transform.rotation = Quaternion.Euler(0, manager.puzzleGateRotation, 0);

        puzzleTextParent = GameObject.FindGameObjectWithTag("PuzzleStateText");
        puzzleText = puzzleTextParent.GetComponent<TextMeshProUGUI>();
        puzzleText.enabled = true;

        puzzleObject = GameObject.FindGameObjectWithTag("PuzzleState");
        puzzleHandler = puzzleObject.GetComponent<PuzzleHandler>();
        isPuzzleComplete = false;
    }

    public override void UpdateState(ObjectiveManager manager)
    {
        isPuzzleComplete = puzzleHandler.isPuzzleGameComplete;
        if (isPuzzleComplete)
        {
            puzzleText.enabled = false;
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
