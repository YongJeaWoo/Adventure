using UnityEngine;

public class EnemyHealth : BaseHealth
{
    [Header("�� �˹� �Ÿ�")]
    [SerializeField] private float knockBackDis;

    public override void TakeDamage(GameObject hitEffectPrefab, Vector3 hitPos,int damage, bool isKnockBack = false)
    {
        if (isKnockBack)
        {
            transform.Translate(-Vector3.forward * knockBackDis);
        }

        base.TakeDamage(hitEffectPrefab, hitPos, damage);
    }
}
