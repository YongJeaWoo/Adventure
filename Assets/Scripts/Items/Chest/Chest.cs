using System;
using System.Collections;
using UnityEngine;

[Serializable]
public struct ItemInfo
{
    public int ItemId;
    public EnumData.E_ItemType ItemType;
}

public class Chest : ItemDrop
{
    private Animator animator;
    private Collider col;

    [Header("»óÀÚ ¿­¸² ÀÌÆÑÆ®")]
    [SerializeField] private GameObject openEffectPrefab;

    [Header("ÆÄ±« ÀÌÆÑÆ®")]
    [SerializeField] private GameObject destroyPrefab;

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider>();
        itemInfo.ItemId = UnityEngine.Random.Range((int)idRange.x, ((int)idRange.y) + 1);
    }

    public override void Open()
    {
        Interacted = true;
        animator.SetTrigger("Open");
        inventorySystem.AddItem(ItemInfo);
    }

    public void OpenEffect()
    {
        Instantiate(openEffectPrefab, transform.position, Quaternion.identity);
    }

    public void ChestDestroy()
    {
        col.enabled = false;
        StartCoroutine(DestroyObjectCoroutine());
    }

    private IEnumerator DestroyObjectCoroutine()
    {
        Instantiate(destroyPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
