using UnityEngine;

public abstract class ItemDrop : MonoBehaviour
{
    protected InventorySystem inventorySystem;
    [Header("������ ����")]
    [SerializeField] protected ItemInfo itemInfo;
    public ItemInfo ItemInfo { get => itemInfo; set => itemInfo = value; }

    [Header("������ ���� ����")]
    [SerializeField] protected Vector2 idRange;

    private bool interacted = false;
    public bool Interacted { get => interacted; set => interacted = value; }

    protected virtual void Awake()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    public abstract void Open();
}
