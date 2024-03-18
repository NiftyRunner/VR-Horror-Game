using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalEscape : TaskBaseState
{
    bool isFinal;
    GameObject finalTextParent;
    TextMeshProUGUI finalText;

    public override void EnterState(ObjectiveManager manager)
    {
        isFinal = true;
        Debug.Log("Default State");

        finalTextParent = GameObject.FindGameObjectWithTag("FinalStateText");
        finalText = finalTextParent.GetComponent<TextMeshProUGUI>();
        finalText.enabled = true;
    }

    public override void UpdateState(ObjectiveManager manager)
    {
        if (!isFinal)
        {
            finalText.enabled = true;
            manager.SwitchState(State.Default);
        }
    }

    public override void OnTriggerExit(ObjectiveManager manager, Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isFinal = false;
        }
    }
}
