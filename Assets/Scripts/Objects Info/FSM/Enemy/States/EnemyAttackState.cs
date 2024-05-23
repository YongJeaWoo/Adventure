using UnityEngine;

public class EnemyAttackState : EnemyAttackAble
{
    [Header ("회전 보간 수치")]
    [SerializeField] protected float smoothValue;
    [Header("공격 포인트")]
    [SerializeField] protected Transform attackHitPoint;
    [Header("공격 이팩트 프리팹")]
    [SerializeField] protected GameObject attackHitEffectPrefab;
    [Header("공격 대상 이름")]
    [SerializeField] private string PlayerName;
    [Header("데미지")]
    [SerializeField] private int damage = 10;

    public override void EnterState(E_State state)
    {
        agent.isStopped = true;
        agent.speed = 0f;
        animator.SetInteger(AnimationName, (int)state);
    }

    public override void UpdateState()
    {
        if (fsm.GetPlayerDistance() > attackDistance)
        {
            fsm.TransitionToState(E_State.Detect);
            return;
        }
        if (fsm.GetPlayerDistance() > detectDistance)
        {
            fsm.TransitionToState(E_State.Giveup);
            return;
        }

        LookAtTarget();
    }

    public override void ExitState()
    {
        
    }

    protected void LookAtTarget()
    {
        if (fsm.GetCurrentState() == fsm.GetCurrentStates()[(int)E_State.Death]) return;

        // 공격 대상을 향한 방향을 계산
        Vector3 direction = (fsm.GetPlayer().transform.position - transform.position).normalized;

        // 회전 쿼터니언 계산
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

        // 보간 회전
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * smoothValue);
    }

    public void Attacking()
    {
        Attack(PlayerName);
    }

    public virtual Collider[] Attack(string targetName, bool isKnockBack = false)
    {
        Collider[] hitObjs = Physics.OverlapSphere(attackHitPoint.position, attackDistance, 1 << LayerMask.NameToLayer(targetName));

        foreach (Collider hitObj in hitObjs)
        {
            if (hitObj.TryGetComponent<CharacterHealth>(out var character))
            {
                var hitPos = hitObj.ClosestPoint(hitObj.transform.position);
                character.TakeDamage(attackHitEffectPrefab, hitPos, damage);
            }
        }

        return hitObjs;
    }
}
