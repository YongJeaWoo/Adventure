using UnityEngine;

public class EnemyWanderState : EnemyAttackAble
{
    [Header ("배회 범위")]
    [SerializeField] protected float wanderDistance;
    [Header("배회 시 이동 속도")]
    [SerializeField] protected float moveSpeed;

    public override void EnterState(E_State state)
    {
        agent.speed = moveSpeed;
        animator.SetInteger(AnimationName, (int)state);
    }

    public override void UpdateState()
    {
        if (fsm.GetPlayerDistance() <= attackDistance)
        {
            fsm.TransitionToState(E_State.Attack);
            return;
        }

        if (fsm.GetPlayerDistance() <= detectDistance)
        {
            fsm.TransitionToState(E_State.Detect);
            return;
        }

        if (fsm.GobackWanderPoint() <= wanderDistance)
        {
            fsm.TransitionToState(E_State.Idle);
            return;
        }

        agent.SetDestination(fsm.GetWanderPoint().position);
    }

    public override void ExitState()
    {

    }
}
