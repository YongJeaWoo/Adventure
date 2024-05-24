using UnityEngine;
using UnityEngine.UI;

public class ItemInfoPanel : MonoBehaviour
{
    [Header("������ �̸�")]
    [SerializeField] private Text itemNameText;
    [Header("������ ����")]
    [SerializeField] private Text itemExplainText;
    [Header("������ ������")]
    [SerializeField] private Image imageIcon;
    [Header("������ ��� �ؽ�Ʈ")]
    [SerializeField] private Text itemUseText;
    [Header("������ ��� �ؽ�Ʈ")]
    [SerializeField] private Text itemCancelText;

    private string useName = $"����ϱ�";
    private string exitName = $"������";

    private InventoryUI inventoryUI;

    private Item item;

    [Header ("������ ���� �г�")]
    [SerializeField] private Transform activeUI;
    public Transform ActiveUI { get => activeUI; set => activeUI = value; }

    public void ShowItemInfo(InventoryUI _inventoryUI, Item _item)
    {
        inventoryUI = _inventoryUI;
        item = _item;

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
        itemNameText.text = $"{item.ItemName}";
        itemExplainText.text = $"{item.ItemExplain}";
    }

    public void HideItemInfo()
    {
        ActiveUI.gameObject.SetActive(false);
    }

    public void OnUseItemButtonClick()
    {
        inventoryUI.UseItem(item);
        PlayerManager.instance.RefreshHpUI((ConsumableItem)item);
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
