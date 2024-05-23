using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    [Header ("공격 위치 참조")]
    [SerializeField] protected Transform attackHitPoint;
    [Header ("공격 시 이펙트")]
    [SerializeField] protected GameObject attackHitEffectPrefab;
    [Header ("공격 범위")]
    [SerializeField] protected float attackRange;
    [Header ("데미지")]
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
