using UnityEngine;

public class BossDetect : MonoBehaviour
{
    private float detectBossRadius = 1.5f;

    private void Update()
    {
        DetectedBoss();
    }

    private void DetectedBoss()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectBossRadius);

        bool bossDetected = false;

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Area"))
            {
                DetectBossArea(collider);
                bossDetected = true;
                break;
            }
        }

        if (!bossDetected)
        {
            BossBattleManager.instance.SetBoss(null);
        }
    }

    private void DetectBossArea(Collider _col)
    {
        var area = _col.GetComponent<BossEnemyArea>();
        var boss = area.CurrentBoss;

        if (boss == null) return;

        var bossFSM = boss.GetComponent<BossFSM>();

        if (bossFSM.IsAlive)
        {
            BossBattleManager.instance.SetBoss(area);
        }
        else
        {
            BossBattleManager.instance.SetBoss(null);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectBossRadius);
    }
}
