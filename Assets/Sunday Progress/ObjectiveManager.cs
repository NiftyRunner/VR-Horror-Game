using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public enum State
{
    Default,
    ObjectCollection,
    PuzzleSolve,
    DungeonSolve,
    FinalTask
}

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField] public GameObject player;

    [SerializeField] State currentState;
    TaskBaseState currentStateScript;

    public DefaultState Default = new DefaultState();
    public WitchObjectCollection ObjectCollection = new WitchObjectCollection();
    public PuzzleRoom PuzzleSolve = new PuzzleRoom();
    public DungeonEscape DungeonSolve = new DungeonEscape();
    public FinalEscape FinalTask = new FinalEscape();

    Dictionary<State, TaskBaseState> stateMap = new Dictionary<State, TaskBaseState>();

    public GameObject objectCollectionObjects;
    public GameObject puzzleGate;
    public float puzzleGateRotation = -90f;
    public GameObject dungeonGate1;
    public GameObject dungeonGate2;

    private void Start()
    {
        stateMap[State.Default] = Default;
        stateMap[State.ObjectCollection] = ObjectCollection;
        stateMap[State.PuzzleSolve] = PuzzleSolve;
        stateMap[State.DungeonSolve] = DungeonSolve;
        stateMap[State.FinalTask] = FinalTask;


        SwitchState(State.Default);

        objectCollectionObjects.SetActive(false);
    }

    private void Update()
    {
        currentStateScript.UpdateState(this);
    }

    public void SwitchState(State state)
    {
        currentState = state;
        currentStateScript = stateMap[state];
        currentStateScript.EnterState(this);
    }
}
