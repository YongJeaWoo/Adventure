using UnityEngine;

public class EnemyIdleState : EnemyAttackAble
{
    protected float timer;
    protected float checkTime;
    [Space (3f)]
    [Header ("대기 랜덤 시간")]
    [SerializeField] protected Vector2 checkTimeRange;

    public override void EnterState(E_State state)
    {
        timer = 0;
        checkTime = Random.Range(checkTimeRange.x, checkTimeRange.y);

        agent.isStopped = true;

        animator.SetInteger("State", (int)state);
    }

    public override void UpdateState()
    {
        timer += Time.deltaTime;
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

        if (timer > checkTime)
        {
            int selectState = Random.Range(0, 2);

            switch (selectState)
            {
                case 0:
                    {
                        timer = 0;
                        checkTime = Random.Range(checkTimeRange.x, checkTimeRange.y);
                    }
                    break;
                case 1:
                    {
                        fsm.TransitionToState(E_State.Wander);
                    }
                    break;
            }
        }
    }

    public override void ExitState()
    {
        timer = 0;
    }
}