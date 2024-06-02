using UnityEngine;

public abstract class ItemDrop : MonoBehaviour
{
    protected InventorySystem inventorySystem;
    [Header("아이템 정보")]
    [SerializeField] protected ItemInfo itemInfo;
    public ItemInfo ItemInfo { get => itemInfo; set => itemInfo = value; }

    [Header("아이템 랜덤 범위")]
    [SerializeField] protected Vector2 idRange;

    private bool interacted = false;
    public bool Interacted { get => interacted; set => interacted = value; }

    protected virtual void Awake()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    public abstract void Open();
}
