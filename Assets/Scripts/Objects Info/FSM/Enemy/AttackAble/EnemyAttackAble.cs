using UnityEngine;

public class EnemyAttackAble : EnemyState
{
    [Header ("공격 범위")]
    [SerializeField] protected float attackDistance;
    [Header("탐지 범위")]
    [SerializeField] protected float detectDistance;

    #region States
    public override void EnterState(E_State state)
    {
        
    }

    public override void ExitState()
    {
        
    }

    public override void UpdateState()
    {
        
    }
    #endregion
}
