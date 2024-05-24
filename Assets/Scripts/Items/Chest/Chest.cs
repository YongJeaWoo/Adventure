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
    [Header ("������ ����")]
    [SerializeField] private ItemInfo itemInfo;
    public ItemInfo ItemInfo { get => itemInfo; set => itemInfo = value; }

    [Header ("������ ���� ����")]
    [SerializeField] private Vector2 idRange;

    [Header("���� ���� ����Ʈ")]
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
