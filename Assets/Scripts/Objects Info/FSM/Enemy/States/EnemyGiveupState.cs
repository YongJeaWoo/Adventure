public class EnemyGiveupState : EnemyWanderState
{
    public override void EnterState(E_State state)
    {
        agent.speed = 0f;
        animator.SetInteger(AnimationName, (int)state);
    }

    public override void UpdateState()
    {
        
    }

    public override void ExitState()
    {
        
    }
}
