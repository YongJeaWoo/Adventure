using System.Collections.Generic;
using UnityEngine;

public class LittleEnemyArea : EnemyArea
{
    [Header("생성할 적들")]
    [SerializeField] private List<GameObject> enemiesList;
    [Header("생성할 위치들")]
    [SerializeField] private Transform[] transforms;

    private float originRespawnTime;

    private bool hasDroppedItem = false;

    private void Start()
    {
        itemInfo.ItemId = Random.Range((int)idRange.x, (int)idRange.y);
        originRespawnTime = respawnTimer;
        Spawn();
    }

    private void Update()
    {
        //Respawn();
        AllEnemiesDeadToItemDrop();
    }

    private void AllEnemiesDeadToItemDrop()
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

        if (allEnemiesDead && !hasDroppedItem)
        {
            Open();
            hasDroppedItem = true;
        }
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

    public override void Open()
    {
        inventorySystem.AddItem(ItemInfo);
    }
}
