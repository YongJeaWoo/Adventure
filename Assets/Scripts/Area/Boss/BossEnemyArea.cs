using UnityEngine;

// 플레이어 들어왔을 때의 감지만 확인
public class BossEnemyArea : EnemyArea
{
    [Header("적 생성 위치")]
    [SerializeField] protected Transform spawnPos;
    [Header("생성할 보스")]
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

    // 리스폰은 Update에서 진행 현재는 게임 방향상 사용하지 않음
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