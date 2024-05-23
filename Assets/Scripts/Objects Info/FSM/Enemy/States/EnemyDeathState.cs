using UnityEngine;

public class EnemyDeathState : EnemyState
{
    protected float timer;
    [Header ("��� ó�� �ð�")]
    [SerializeField] protected float deathDelayTime;

    [Header("��� ó�� ����Ʈ")]
    [SerializeField] protected GameObject destroyParticlePrefab;

    private string AnimationDeathName = "Death";

    public override void EnterState(E_State state)
    {
        timer = 0f;
        agent.isStopped = true;
        animator.SetBool(AnimationDeathName, true);
    }

    public override void UpdateState()
    {
        timer += Time.deltaTime;

        if (timer >= deathDelayTime)
        {
            Instantiate(destroyParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public override void ExitState()
    {
        timer = 0f;
    }
}
