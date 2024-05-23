using UnityEngine;

public class EnemyHealth : BaseHealth
{
    [Header("Àû ³Ë¹é °Å¸®")]
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
