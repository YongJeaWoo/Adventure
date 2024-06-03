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
    private ConsumableItem consumableItem;

    [Header ("������ ���� �г�")]
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

        if (curseItemInfo.IsItemOpen(consumableItem.ItemId))
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

        if (consumableItem != null && consumableItem.ConsumerType == EnumData.E_ConsumerType.Curse)
        {
            curseItemInfo.MarkItemAsUsed(consumableItem.ItemId);
        }

        switch (consumableItem.ConsumerType)
        {
            case EnumData.E_ConsumerType.HpUp:
                var health = PlayerManager.instance.GetPlayer().GetComponent<CharacterHealth>();
                health.HpUp(consumableItem.Value);
                break;
            case EnumData.E_ConsumerType.Curse:
                var (name, explain) = curseItemInfo.GetUseItemMessage(consumableItem);
                itemNameText.text = name;
                itemExplainText.text = explain;
                PlayerManager.instance.CurseEffectToDamage(consumableItem);
                break;
            case EnumData.E_ConsumerType.BuffAttack:
                PlayerManager.instance.IncreaseAttack(consumableItem);
                break;
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
