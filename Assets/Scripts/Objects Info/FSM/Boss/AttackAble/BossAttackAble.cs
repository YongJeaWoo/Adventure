using UnityEngine;

public class BossAttackAble : BossState
{
    [Header("Ž�� ����")]
    [SerializeField] protected float thinkDistance;
    [Header("���� ����")]
    [SerializeField] protected float attackDistance;
    [Header("���� ����Ʈ")]
    [SerializeField] protected Transform attackHitPoint;
    [Header("ȸ�� ���� ��ġ")]
    [SerializeField] protected float smoothValue;
    [Header("���� ����Ʈ ������")]
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

        // ���� ����� ���� ������ ���
        Vector3 direction = (targetPos - transform.position).normalized;

        // ȸ�� ���ʹϾ� ���
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

        // ���� ȸ��
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
