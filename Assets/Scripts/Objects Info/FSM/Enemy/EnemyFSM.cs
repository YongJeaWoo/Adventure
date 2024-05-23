using System.Collections.Generic;
using UnityEngine;

public enum E_State
{
    Idle,
    Wander,
    Detect,
    Attack,
    Giveup,
    Hit,
    Death
}

public class EnemyFSM : FSMController<E_State, EnemyState, EnemyFSM>
{
    [Header ("배회 포인트")]
    [SerializeField] private Transform[] wanderPoints;
    private HashSet<Transform> occupiedPoints = new HashSet<Transform>();


    protected override void Start()
    {
        base.Start();
        TransitionToState(E_State.Idle);
    }

    public void Hit()
    {
        if (CurrentState == MyStates[(int)E_State.Death]) return;
        TransitionToState(E_State.Hit);
    }

    public HashSet<Transform> GetOccupiedPoints() => occupiedPoints;
    public Transform[] GetWanderPoints() => wanderPoints;
}