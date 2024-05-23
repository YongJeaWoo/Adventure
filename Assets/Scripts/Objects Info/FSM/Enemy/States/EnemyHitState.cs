
public class EnemyHitState : EnemyAttackAble, IHit
{
    private bool isHit;
    public bool IsHit { get => isHit; set => isHit = value; }

    public override void EnterState(E_State state)
    {
        agent.isStopped = true;

        if (health.CurrentHp <= 0)
        {
            fsm.TransitionToState(E_State.Death);
            return;
        }

        IsHit = true;
        animator.SetInteger(AnimationName, (int)state);
    }
    
    public override void UpdateState()
    {
        if (health.CurrentHp <= 0 || IsHit) return;

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
        IsHit = false;
    }

    public void Hit()
    {
        if (fsm.CurrentState == fsm.MyStates[(int)E_State.Death]) return;
        fsm.TransitionToState(E_State.Hit);
    }
}
