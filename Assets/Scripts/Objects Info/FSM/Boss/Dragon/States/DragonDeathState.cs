using UnityEngine;

public class DragonDeathState : BossState
{
    [Header("��� ó�� �ð�")]
    [SerializeField] protected float deathDelayTime;
    [Header("��� ó�� ����Ʈ")]
    [SerializeField] protected GameObject destroyParticlePrefab;

    private string AnimationDeathName = "Death";

    private void Start()
    {

    }

    public override void EnterState(E_DragonState state)
    {
        timer = 0f;
        agent.isStopped = true;
        animator.SetBool(AnimationDeathName, true);
    }

    public override void UpdateState()
    {
        Death();
    }

    public override void ExitState()
    {
        timer = 0f;
    }

    private void Death()
    {
        timer += Time.deltaTime;

        if (timer >= deathDelayTime)
        {
            Instantiate(destroyParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameManager.instance.GameOver();
            fsm.IsAlive = false;
            return;
        }
    }
}
