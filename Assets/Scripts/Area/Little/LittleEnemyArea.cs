using System.Collections.Generic;
using UnityEngine;

public class LittleEnemyArea : EnemyArea
{
    [Header("������ ����")]
    [SerializeField] private List<GameObject> enemiesList;
    [Header("������ ��ġ��")]
    [SerializeField] private Transform[] transforms;

    private float originRespawnTime;

    private void Start()
    {
        originRespawnTime = respawnTimer;
        Spawn();
    }

    private void Update()
    {
        Respawn();
    }

    protected override void Respawn()
    {
        bool allEnemiesDead = true;

        foreach (Transform spawnPos in transforms)
        {
            if (spawnPos.childCount > 0)
            {
                allEnemiesDead = false;
                break;
            }

        }

        if (allEnemiesDead)
        {
            respawnTimer -= Time.deltaTime;

            if (respawnTimer <= 0)
            {
                Spawn();
                respawnTimer = originRespawnTime;
            }
        }
    }

    protected override void Spawn()
    {
        List<GameObject> weightedEnemiesList = new List<GameObject>(enemiesList);

        foreach (Transform spawnPos in transforms)
        {
            int randomIndex = Random.Range(0, weightedEnemiesList.Count);
            GameObject enemyPrefab = weightedEnemiesList[randomIndex];
            weightedEnemiesList.Remove(enemyPrefab);

            var go = Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
            go.transform.SetParent(spawnPos);

            if (weightedEnemiesList.Count == 0)
            {
                weightedEnemiesList = new List<GameObject>(enemiesList);
            }
        }
    }
}
