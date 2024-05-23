public class EnemyGiveupState : EnemyWanderState
{
    public override void EnterState(E_State state)
    {
        agent.speed = 0f;
        animator.SetInteger(AnimationName, (int)state);

        Invoke(nameof(Test), 1.5f);
    }

    public override void UpdateState()
    {
        
    }

    public override void ExitState()
    {
        
    }

    private void Test()
    {
        fsm.TransitionToState(E_State.Idle);
    }
}
