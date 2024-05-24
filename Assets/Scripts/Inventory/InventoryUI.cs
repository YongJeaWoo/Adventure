using System.Collections;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventorySystem inventorySystem;
    [SerializeField] private InitializeInventory initializeInventory;
    public InitializeInventory InitializeInventory { get => initializeInventory; set => initializeInventory = value; }

    [Header("아이템 정보 표시 패널")]
    [SerializeField] private ItemInfoPanel itemInfoPanel;
    public ItemInfoPanel ItemInfoPanel { get => itemInfoPanel; set => itemInfoPanel = value; }

    public void UpdateInventoryUI()
    {
        for (int i = 0; i < InitializeInventory.ItemSlotsPos.Length; i++)
        {
            InitializeInventory.ItemSlotUI[i].ClearItemUI();
        }

        for (int i = 0; i < inventorySystem.GetItemList.Count; i++)
        {
            Item item = inventorySystem.GetItemList[i];
            InitializeInventory.ItemSlotUI[i].Init(this, item);
        }

        ItemInfoPanel.HideItemInfo();

        ItemAllDeSelect();
    }

    public void ItemSelect(Item _item)
    {
        ItemAllDeSelect();
        ItemInfoPanel.ShowItemInfo(this, _item);
    }

    public void ItemAllDeSelect()
    {
        for (int i = 0; i < InitializeInventory.ItemSlotsPos.Length; i++)
        {
            InitializeInventory.ItemSlotUI[i].ItemDeSelect();
        }

        ItemInfoPanel.HideItemInfo();
    }

    public void UseItem(Item _useItem)
    {
        if (_useItem.Type == EnumData.E_ItemType.Consumable)
        {
            if (_useItem.ItemCount > 1)
            {
                _useItem.ItemCount--;
                UpdateInventoryUI();
                return;
            }
        }

        inventorySystem.RemoveItem(_useItem);
    }

    public void RemoveItem(Item _item)
    {
        inventorySystem.RemoveItem(_item);
        ItemInfoPanel.HideItemInfo();
    }
}
