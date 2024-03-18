using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : TaskBaseState
{
    bool isDefault;
    GameObject defaultObject;

    public override void EnterState(ObjectiveManager manager)
    {
        isDefault = true;
        Debug.Log("Default State");
        defaultObject = GameObject.FindGameObjectWithTag("Default");
    }

    public override void UpdateState(ObjectiveManager manager)
    {
        if (!isDefault)
        {
            manager.SwitchState(State.ObjectCollection);
        }
    }

    public override void OnTriggerExit(ObjectiveManager manager, Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isDefault = false;
        }
    }
}
