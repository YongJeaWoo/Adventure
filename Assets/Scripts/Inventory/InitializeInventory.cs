using UnityEngine;

public class InitializeInventory : MonoBehaviour
{
    [Header("������ ǥ�� ��ġ��")]
    [SerializeField] private RectTransform[] itemSlotsPos;
    public RectTransform[] ItemSlotsPos { get => itemSlotsPos; set => itemSlotsPos = value; }
    // ������ ����
    [Header("������ ���� ������")]
    [SerializeField] private GameObject itemSlotPrefab;

    private ItemSlotUI[] itemSlotUI;
    public ItemSlotUI[] ItemSlotUI { get => itemSlotUI; set => itemSlotUI = value; }

    private void Start()
    {
        InitInventoryUI();
    }

    private void InitInventoryUI()
    {
        ItemSlotUI = new ItemSlotUI[ItemSlotsPos.Length];

        for (int i = 0; i < ItemSlotsPos.Length; i++)
        {
            ItemSlotUI[i] = Instantiate(itemSlotPrefab, ItemSlotsPos[i]).GetComponent<ItemSlotUI>();
        }
    }
}
