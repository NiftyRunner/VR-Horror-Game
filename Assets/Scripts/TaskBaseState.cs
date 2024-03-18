using UnityEngine;

public abstract class TaskBaseState
{
    public abstract void EnterState(ObjectiveManager manager);
    
    public abstract void UpdateState(ObjectiveManager manager);

    public abstract void OnTriggerExit(ObjectiveManager manager, Collision collision);
}
