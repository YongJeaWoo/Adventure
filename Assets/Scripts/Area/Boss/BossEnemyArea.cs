using UnityEngine;

// �÷��̾� ������ ���� ������ Ȯ��
public class BossEnemyArea : EnemyArea
{
    [Header("�� ���� ��ġ")]
    [SerializeField] protected Transform spawnPos;
    [Header("������ ����")]
    [SerializeField] private GameObject bossPrefab;

    private GameObject currentBoss;
    public GameObject CurrentBoss { get => currentBoss; set => currentBoss = value; }

    private float originRespawnTime;

    [SerializeField] private GameObject bossObj;
    public GameObject BossObj { get => bossObj; set => bossObj = value; }

    private BossFSM fsm;

    private void Start()
    {
        originRespawnTime = respawnTimer;
        Spawn();
    }

    protected override void Spawn()
    {
        BossObj = Instantiate(bossPrefab, spawnPos.transform.position, Quaternion.identity);
        BossObj.transform.SetParent(spawnPos.transform);
        fsm = BossObj.GetComponent<BossFSM>();
        CurrentBoss = BossObj;
        fsm.IsAlive = true;
        GameManager.instance.SetBossFSM(fsm);
    }

    // �������� Update���� ���� ����� ���� ����� ������� ����
    protected override void Respawn()
    {
        if (!fsm.IsAlive)
        {
            respawnTimer -= Time.deltaTime;

            if (respawnTimer <= 0f)
            {
                Spawn();
                respawnTimer = originRespawnTime;
            }
        }
    }
}