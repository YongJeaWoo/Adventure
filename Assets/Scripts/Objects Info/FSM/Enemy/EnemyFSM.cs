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
    [Header ("��ȸ ����Ʈ")]
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

    public Transform GetWanderPoint() => wanderPoint;
}