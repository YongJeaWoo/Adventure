using UnityEngine;

public class EnemyAttackState : EnemyAttackAble
{
    [Header ("ȸ�� ���� ��ġ")]
    [SerializeField] protected float smoothValue;
    [Header("���� ����Ʈ")]
    [SerializeField] protected Transform attackHitPoint;
    [Header("���� ����Ʈ ������")]
    [SerializeField] protected GameObject attackHitEffectPrefab;
    [Header("���� ��� �̸�")]
    [SerializeField] private string PlayerName;
    [Header("������")]
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

        // ���� ����� ���� ������ ���
        Vector3 direction = (fsm.GetPlayer().transform.position - transform.position).normalized;

        // ȸ�� ���ʹϾ� ���
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

        // ���� ȸ��
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
