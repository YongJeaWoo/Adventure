public class DragonWarningState : BossAttackAble
{

    public override void EnterState(E_DragonState state)
    {
        animator.SetInteger(AnimationName, (int)state);
    }

    public override void UpdateState()
    {
        GotoSleep();
    }

    public override void ExitState()
    {
        
    }

    private void GotoSleep()
    {
        if (fsm.GetPlayerDistance() > thinkDistance)
        {
            fsm.TransitionToState(E_DragonState.Sleep);
            return;
        }
    }
}
