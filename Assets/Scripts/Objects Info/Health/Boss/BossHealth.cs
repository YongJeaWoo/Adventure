using UnityEngine;

public class BossHealth : BaseHealth
{
    private BossFSM fsm;

    private void Awake()
    {
        fsm = GetComponent<BossFSM>();
    }

    public override void TakeDamage(GameObject hitEffectPrefab, Vector3 hitPos, int damage, bool isKnockBack = false)
    {
        base.TakeDamage(hitEffectPrefab, hitPos, damage);
    }

    public override void HpDown(int _value)
    {
        base.HpDown(_value);

        if (CurrentHp <= 0)
        {
            fsm.IsAlive = false;
        }
    }
}
