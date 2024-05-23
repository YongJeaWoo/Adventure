using System.Collections.Generic;
using UnityEngine;

public class EnemyWanderState : EnemyAttackAble
{
    [Header ("��ȸ ����")]
    [SerializeField] protected float radius;
    [Header("��ȸ �� �̵� �ӵ�")]
    [SerializeField] protected float moveSpeed;

    // ���� �� ��ȸ ����Ʈ
    private Transform currentTargetPoint;

    public override void EnterState(E_State state)
    {
        agent.speed = moveSpeed;
        animator.SetInteger(AnimationName, (int)state);
    }

    public override void UpdateState()
    {
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

        //if (Vector3.Distance(transform.position, currentTargetPoint.position) <= agent.stoppingDistance)
        //{
        //    RandomPoint();
        //}
    }

    public override void ExitState()
    {
        
    }

    private void RandomPoint()
    {
        if (fsm.GetWanderPoints() == null || fsm.GetWanderPoints().Length == 0)
        {
            return;
        }

        List<Transform> availablePoints = new List<Transform> (fsm.GetWanderPoints());

        foreach (var point in fsm.GetOccupiedPoints())
        {
            availablePoints.Add(point);
        }

        if (availablePoints.Count == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, availablePoints.Count);
        currentTargetPoint = availablePoints[randomIndex];
        fsm.GetOccupiedPoints().Add(currentTargetPoint);

        agent.SetDestination(currentTargetPoint.position);
    }
}
