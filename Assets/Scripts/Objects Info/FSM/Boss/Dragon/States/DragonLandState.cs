public class DragonLandState : BossState
{
    private void Start()
    {

    }

    public override void EnterState(E_DragonState state)
    {
        animator.SetInteger(AnimationName, (int)state);
    }

    public override void UpdateState()
    {
        
    }

    public override void ExitState()
    {
        
    }
}
