using UnityEngine;

public class EnemyDetectState : EnemyAttackAble
{
    [Header ("추적 속도")]
    [SerializeField] protected float detectSpeed;

    public override void EnterState(E_State state)
    {
        agent.speed = detectSpeed;
        animator.SetInteger(AnimationName, (int)state);
    }

    public override void UpdateState()
    {
        if (fsm.GetPlayerDistance() <= attackDistance)
        {
            fsm.TransitionToState(E_State.Attack);
            return;
        }

        if (fsm.GetPlayerDistance() > detectDistance)
        {
            fsm.TransitionToState(E_State.Giveup);
            return;
        }

        agent.isStopped = false;
        agent.SetDestination(fsm.GetPlayer().transform.position);
    }

    public override void ExitState()
    {
        
    }
}
