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
    [SerializeField] private Transform wanderPoint;


    protected override void Start()
    {
        base.Start();
        TransitionToState(E_State.Idle);
        wanderPoint = transform.parent;
    }

    public void Hit()
    {
        if (CurrentState == MyStates[(int)E_State.Death]) return;
        TransitionToState(E_State.Hit);
    }

    public float GobackWanderPoint() => Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(wanderPoint.position.x, 0, wanderPoint.position.z));
    public Transform GetWanderPoint() => wanderPoint;
}