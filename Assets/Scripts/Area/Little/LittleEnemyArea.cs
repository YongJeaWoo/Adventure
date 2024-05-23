using System.Collections.Generic;
using UnityEngine;

public class LittleEnemyArea : EnemyArea
{
    [Header("생성할 적들")]
    [SerializeField] private List<GameObject> enemiesList;
    [Header("생성할 위치들")]
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
        int randomIndex = Random.Range(0, enemiesList.Count);

        GameObject enemyPrefab = enemiesList[randomIndex];

        foreach (Transform spawnPos in transforms)
        {
            var go = Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
            go.transform.SetParent(spawnPos);
        }
    }
}
