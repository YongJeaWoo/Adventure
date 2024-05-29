using UnityEngine;
using UnityEngine.UI;

public class ItemInfoPanel : MonoBehaviour
{
    [Header("아이템 이름")]
    [SerializeField] private Text itemNameText;
    [Header("아이템 설명")]
    [SerializeField] private Text itemExplainText;
    [Header("아이템 아이콘")]
    [SerializeField] private Image imageIcon;
    [Header("아이템 사용 텍스트")]
    [SerializeField] private Text itemUseText;
    [Header("아이템 취소 텍스트")]
    [SerializeField] private Text itemCancelText;

    private string useName = $"사용하기";
    private string exitName = $"나가기";

    private InventoryUI inventoryUI;

    private Item item;
    private ConsumableItem consumableItem;

    [Header ("아이템 정보 패널")]
    [SerializeField] private Transform activeUI;
    public Transform ActiveUI { get => activeUI; set => activeUI = value; }

    private ConsumableCurseItemInfo curseItemInfo;

    private void Awake()
    {
        curseItemInfo = FindObjectOfType<ConsumableCurseItemInfo>();
    }

    public void ShowItemInfo(InventoryUI _inventoryUI, Item _item)
    {
        inventoryUI = _inventoryUI;
        item = _item;
        consumableItem = (ConsumableItem)item;

        if (item.Type == EnumData.E_ItemType.Consumable)
        {
            itemUseText.text = useName;
            itemCancelText.text = exitName;
        }
        else
        {
            itemUseText.text = $"";
            itemCancelText.text = $"";
        }

        imageIcon.sprite = _item.ItemIconImage;
        ActiveUI.gameObject.SetActive(true);

        if (consumableItem != null)
        {
            var (name, explain) = curseItemInfo.GetUseItemMessage(consumableItem);
            itemNameText.text = name;
            itemExplainText.text = explain;
        }
        else
        {
            itemNameText.text = item.ItemName;
            itemExplainText.text = item.ItemExplain;
        }
    }

    public void HideItemInfo()
    {
        ActiveUI.gameObject.SetActive(false);
    }

    public void OnUseItemButtonClick()
    {
        inventoryUI.UseItem(item);
        PlayerManager.instance.RefreshHpUI(consumableItem);

        if (consumableItem != null && consumableItem.ConsumerType == EnumData.E_ConsumerType.Curse)
        {
            curseItemInfo.MarkItemAsUsed(consumableItem.ItemId);
        }
    }

    public void OnExitButtonClick()
    {
        inventoryUI.ItemAllDeSelect();
        HideItemInfo();
    }

    public void OnRemoveItemButtonClick()
    {
        if (item == null) return;
        inventoryUI.RemoveItem(item);
    }
}
