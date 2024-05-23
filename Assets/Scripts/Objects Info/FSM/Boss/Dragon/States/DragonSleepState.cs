using UnityEngine;

public class DragonSleepState : BossAttackAble
{
    [Header ("상태 전환 시간")]
    [SerializeField] protected float changeTimer;

    private void Start()
    {
        
    }

    public override void EnterState(E_DragonState state)
    {
        health.CurrentHp = health.Hp;
        agent.isStopped = true;
        animator.SetInteger(AnimationName, (int)state);
    }

    public override void UpdateState()
    {
        WakeupBoss();
    }

    public override void ExitState()
    {
        
    }

    public void WakeupBoss()
    {
        if (fsm.GetPlayerDistance() <= thinkDistance)
        {
            fsm.TransitionToState(E_DragonState.Warning);
            return;
        }
        if (fsm.GetPlayerDistance() > thinkDistance)
        {
            fsm.TransitionToState(E_DragonState.Sleep);
            return;
        }
    }
}
