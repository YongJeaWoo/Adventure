using UnityEngine;

public class DragonHitState : BossAttackAble, IHit
{
    private bool isHit;
    public bool IsHit { get => isHit; set => isHit = value; }

    public override void EnterState(E_DragonState state)
    {
        agent.isStopped = true;

        if (health.CurrentHp <= 0)
        {
            fsm.TransitionToState(E_DragonState.Death);
            return;
        }

        IsHit = true;
        animator.SetInteger(AnimationName, (int)state);
    }

    public override void UpdateState()
    {
        if (health.CurrentHp <= 0 || IsHit) return;

        CountAttack();
    }

    public override void ExitState()
    {
        IsHit = false;
    }

    private void CountAttack()
    {
        float attackProbability = 0.7f;

        float randomValue = Random.value;

        if (randomValue <= attackProbability && fsm.GetPlayerDistance() <= thinkDistance)
        {
            fsm.TransitionToState(E_DragonState.TailAttack);
            return;
        }

        fsm.TransitionToState(E_DragonState.Idle);
    }

    public void Hit()
    {
        if (fsm.CurrentState == fsm.MyStates[(int)E_DragonState.Death]) return;
        fsm.TransitionToState(E_DragonState.Hit);
    }
}
