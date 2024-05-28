using System.Collections;
using UnityEngine;

public class DragonFlyState : BossState
{
    [Header ("공격 대기 시간")]
    [SerializeField] protected float attackTime;

    public override void EnterState(E_DragonState state)
    {
        agent.isStopped = true;
        animator.SetInteger(AnimationName, (int)state);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        ReadyTimer();
    }

    public override void ExitState()
    {
        StopCoroutine(nameof(WaitFlyAttack));
    }

    private void ReadyTimer()
    {
        timer += Time.deltaTime;
        if (timer > attackTime)
        {
            StartCoroutine(WaitFlyAttack());
            return;
        }
    }

    private IEnumerator WaitFlyAttack()
    {
        yield return new WaitForSeconds(0.5f);
        fsm.TransitionToState(E_DragonState.FlyAttack);
        yield return null;
    }
}
