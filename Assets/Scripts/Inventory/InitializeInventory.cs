using UnityEngine;

public class InitializeInventory : MonoBehaviour
{
    [Header("아이템 표시 위치들")]
    [SerializeField] private RectTransform[] itemSlotsPos;
    public RectTransform[] ItemSlotsPos { get => itemSlotsPos; set => itemSlotsPos = value; }
    // 아이템 슬롯
    [Header("아이템 슬롯 프리팹")]
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
