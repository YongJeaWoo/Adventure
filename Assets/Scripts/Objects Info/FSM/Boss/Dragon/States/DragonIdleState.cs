using UnityEngine;

public class DragonIdleState : DragonSleepState
{
    [Header ("상태 시간")]
    [SerializeField] private Vector2 randomThinkTimer;

    public override void EnterState(E_DragonState state)
    {
        changeTimer = Random.Range(randomThinkTimer.x, randomThinkTimer.y);
        agent.isStopped = true;
        animator.SetInteger(AnimationName, (int)state);
    }

    public override void UpdateState()
    {
        ChangeState();
    }

    public override void ExitState()
    {
        timer = 0f;
    }

    private void ChangeState()
    {
        timer += Time.deltaTime;

        if (timer > changeTimer)
        {
            fsm.TransitionToState(E_DragonState.Thinking);
            return;
        }

        if (fsm.GetPlayerDistance() > thinkDistance)
        {
            fsm.TransitionToState(E_DragonState.Sleep);
            return;
        }
    }
}
