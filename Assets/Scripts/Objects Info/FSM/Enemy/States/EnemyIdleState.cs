public class EnemyIdleState : EnemyAttackAble
{
    public override void EnterState(E_State state)
    {
        agent.isStopped = true;
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
    }

    public override void ExitState()
    {
        
    }
}