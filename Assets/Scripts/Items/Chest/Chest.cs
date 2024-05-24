using System;
using UnityEngine;

[Serializable]
public struct ItemInfo
{
    public int ItemId;
    public EnumData.E_ItemType ItemType;
}

public class Chest : Interactive
{
    [Header ("아이템 정보")]
    [SerializeField] private ItemInfo itemInfo;
    public ItemInfo ItemInfo { get => itemInfo; set => itemInfo = value; }

    [Header ("아이템 랜덤 범위")]
    [SerializeField] private Vector2 idRange;

    [Header("상자 열림 이팩트")]
    [SerializeField] private GameObject openEffectPrefab;

    protected override void Awake()
    {
        base.Awake();
        itemInfo.ItemId = UnityEngine.Random.Range((int)idRange.x, ((int)idRange.y) + 1);
    }

    public override void Open()
    {
        animator.SetTrigger("Open");
        inventorySystem.AddItem(ItemInfo);
    }

    public void OpenEffect()
    {
        Instantiate(openEffectPrefab, transform.position, Quaternion.identity);
    }
}
