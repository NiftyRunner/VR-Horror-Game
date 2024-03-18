using UnityEngine;

public class GetTrigger : MonoBehaviour
{
    [SerializeField] State nextState;
    [SerializeField] ObjectiveManager manager;
    public bool currentTaskComplete;

    private void OnTriggerExit(Collider other)
    {
        currentTaskComplete = true;
        manager.SwitchState(nextState);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentTaskComplete = false;
    }
}
