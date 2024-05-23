using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [Header("아이템 배경 이미지")]
    [SerializeField] private Image itemBackgroundImage;
    [Header("아이템 아이콘 이미지")]
    [SerializeField] private Image itemIconImage;
    [Header("아이템 획득 갯수")]
    [SerializeField] private Text itemCountText;
    [Header("아이템 카운트 표시 배경")]
    [SerializeField] private GameObject itemCountBackground;

    private InventoryUI inventoryUI;
    private Item item = null;

    [Space(5f)]
    [Header("선택된 색")]
    [SerializeField] private Color32 selectColor;
    [Space(2f)]
    [Header("선택 해제 색")]
    [SerializeField] private Color32 deSelectColor;

    private bool isSelected = false;

    public void Init(InventoryUI _inventoryUI, Item _item)
    {
        inventoryUI = _inventoryUI;
        item = _item;

        itemIconImage.sprite = item.ItemIconImage;

        if (item.ItemCount > 0)
        {
            itemCountBackground.SetActive(true);
            itemCountText.text = $"{item.ItemCount}";
        }
    }

    public void ClearItemUI()
    {
        itemBackgroundImage.color = deSelectColor;
        itemIconImage.sprite = null;
        item = null;
        itemCountBackground.SetActive(false);
        itemCountText.text = $"0";
    }

    public void ItemSelect()
    {
        if (item == null) return;

        inventoryUI.ItemSelect(item);

        if (!isSelected)
        {
            itemBackgroundImage.color = selectColor;
            isSelected = true;
        }
    }

    public void ItemDeSelect()
    {
        if (isSelected)
        {
            itemBackgroundImage.color = deSelectColor;
            isSelected = false;
        }
    }
}
