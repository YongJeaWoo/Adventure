public class DragonTailAttackState : BossAttackAble
{
    private void Start()
    {
        SetDamage(fsm.BossDataSOJ.TailDamage);
    }

    public override void EnterState(E_DragonState state)
    {
        agent.isStopped = true;
        agent.speed = 0f;
        animator.SetInteger(AnimationName, (int)state);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void ExitState()
    {
        
    }

    public void TailAttack()
    {
        Attack(fsm.TargetName);
    }
}
