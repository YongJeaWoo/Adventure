using UnityEngine;

public class BossAttackAble : BossState
{
    [Header("탐지 범위")]
    [SerializeField] protected float thinkDistance;
    [Header("공격 범위")]
    [SerializeField] protected float attackDistance;
    [Header("공격 포인트")]
    [SerializeField] protected Transform attackHitPoint;
    [Header("회전 보간 수치")]
    [SerializeField] protected float smoothValue;
    [Header("공격 이팩트 프리팹")]
    [SerializeField] protected GameObject attackHitEffectPrefab;
    
    protected int damage;

    private void Start()
    {

    }

    public override void EnterState(E_DragonState state)
    {

    }

    public override void UpdateState()
    {
        LookAtTarget(fsm.GetPlayer().transform.position);
    }

    public override void ExitState()
    {

    }

    protected void SetDamage(int _newDamage)
    {
        damage = _newDamage;
    }

    protected void LookAtTarget(Vector3 targetPos)
    {
        if (fsm.GetCurrentState() == fsm.GetCurrentStates()[(int)E_State.Death]) return;

        // 공격 대상을 향한 방향을 계산
        Vector3 direction = (targetPos - transform.position).normalized;

        // 회전 쿼터니언 계산
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

        // 보간 회전
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * smoothValue);
    }

    protected virtual Collider[] Attack(string targetName, bool isKnockBack = false)
    {
        Collider[] hitObj = Physics.OverlapSphere(attackHitPoint.position, attackDistance, 1 << LayerMask.NameToLayer(targetName));

        foreach (Collider obj in hitObj)
        {
            if (obj.TryGetComponent<CharacterHealth>(out var character))
            {
                var hitPos = obj.ClosestPoint(obj.transform.position);
                character.TakeDamage(attackHitEffectPrefab, hitPos, damage);
            }
        }

        return hitObj;
    }
}
