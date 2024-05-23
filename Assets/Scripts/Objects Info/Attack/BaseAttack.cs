using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    [Header ("���� ��ġ ����")]
    [SerializeField] protected Transform attackHitPoint;
    [Header ("���� �� ����Ʈ")]
    [SerializeField] protected GameObject attackHitEffectPrefab;
    [Header ("���� ����")]
    [SerializeField] protected float attackRange;
    [Header ("������")]
    [SerializeField] protected int damage;

    protected bool takeDamaged;

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public virtual Collider[] Attack(string targetName, bool isKnockBack = false)
    {
        Collider[] hitObjs = Physics.OverlapSphere(attackHitPoint.position, attackRange, 1 << LayerMask.NameToLayer(targetName));

        foreach (Collider hitObj in hitObjs)
        {
            if (hitObj.TryGetComponent<BaseHealth>(out var enemyHealth))
            {
                var hitPos = hitObj.ClosestPoint(hitObj.transform.position);
                enemyHealth.TakeDamage(attackHitEffectPrefab, hitPos, damage, true);
                hitObj.GetComponent<IHit>().Hit();
            }
        }

        return hitObjs;
    }
}
