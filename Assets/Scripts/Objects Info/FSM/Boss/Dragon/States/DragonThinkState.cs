using UnityEngine;

public class DragonThinkState : BossAttackAble
{
    [Header ("생각 시간")]
    [SerializeField] protected float checkTime;

    private int attackFirstIndex = (int)E_DragonState.FaceAttack;
    private int attackLastIndex = (int)E_DragonState.Fly;

    public override void EnterState(E_DragonState state)
    {
        timer = 0;
        agent.isStopped = true;
        animator.SetInteger("State", (int)state);
    }

    public override void UpdateState()
    {
        ThinkPattern();
    }

    public override void ExitState()
    {
        timer = 0f;
    }

    private void ThinkPattern()
    {
        timer += Time.deltaTime;

        if (timer > checkTime)
        {
            var select = Random.Range(attackFirstIndex, attackLastIndex + 1);

            switch (select)
            {
                case (int)E_DragonState.FaceAttack:
                    {
                        fsm.TransitionToState(E_DragonState.FaceAttack);
                        return;
                    }
                case (int)E_DragonState.TailAttack:
                    {
                        fsm.TransitionToState(E_DragonState.TailAttack);
                        return;
                    }
                case (int)E_DragonState.FireAttack:
                    {
                        fsm.TransitionToState(E_DragonState.FireAttack);
                        return;
                    }
                case (int)E_DragonState.Fly:
                    {
                        fsm.TransitionToState(E_DragonState.Fly);
                        return;
                    }
            }
        }
    }
}
