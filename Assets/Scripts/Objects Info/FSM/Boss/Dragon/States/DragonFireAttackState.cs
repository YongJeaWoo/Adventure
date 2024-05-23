using UnityEngine;

public class DragonFireAttackState : BossAttackAble
{
    [Header ("ºÒ²É ±¸Ã¼ ÇÁ¸®ÆÕ")]
    [SerializeField] protected GameObject firePrefab;

    public override void EnterState(E_DragonState state)
    {
        agent.isStopped = true;
        animator.SetInteger(AnimationName, (int)state);
    }

    public override void UpdateState()
    {
        
    }

    public override void ExitState()
    {
        
    }

    public void AnimationFireEvent()
    {
        var firePointY = attackHitPoint.transform.position.y + 1.5f;
        var finalPosition = new Vector3(attackHitPoint.transform.position.x, firePointY, attackHitPoint.transform.position.z);
        Instantiate(firePrefab, finalPosition, Quaternion.identity);
    }

    public void LookPlayer()
    {
        LookAtTarget(fsm.GetPlayer().transform.position);
    }
}
