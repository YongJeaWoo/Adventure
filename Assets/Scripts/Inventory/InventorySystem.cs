using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [Header("아이템 스크립터블 오브젝트 리스트")]
    [SerializeField] private ItemList[] itemList;

    private int inventorySize;

    [SerializeField] private InventoryUI inventoryUI;
    public InventoryUI InventoryUI { get => inventoryUI; set => inventoryUI = value; }

    // 획득한 아이템 리스트
    private List<Item> getItemList = new List<Item>();
    public List<Item> GetItemList { get => getItemList; set => getItemList = value; }

    private void Start()
    {
        inventorySize = InventoryUI.InitializeInventory.ItemSlotsPos.Length;
    }

    public bool AddItem(ItemInfo _itemInfo)
    {
        if (_itemInfo.ItemType == EnumData.E_ItemType.Consumable)
        {
            ConsumableItem cItem = (ConsumableItem)GetItemList.FirstOrDefault(item => item.ItemId == _itemInfo.ItemId);

            if (cItem != null)
            {
                cItem.ItemCount++;

                var info = UIManager.instance.ShowUIPrefab.GetComponent<ItemShowInfo>();
                if (cItem.OnceOpen)
                {
                    info.ItemNameText.text = cItem.OnceOpenName;
                }
            }
            else
            {
                if (GetItemList.Count >= inventorySize)
                {
                    return false;
                }

                Item item = itemList[(int)EnumData.E_ItemType.Consumable].ItemsList.FirstOrDefault(item => item.ItemId == _itemInfo.ItemId).Clone();

                if (item != null)
                {
                    GetItemList.Add(item);
                    var info = UIManager.instance.ShowUIPrefab.GetComponent<ItemShowInfo>();
                    info.ItemNameText.text = item.ItemName;
                    info.ItemIconImage.sprite = item.ItemIconImage;
                }
            }
        }

        InventoryUI.UpdateInventoryUI();
        UIManager.instance.AddItemShowText();

        return true;
    }

    public void RemoveItem(Item _item)
    {
        if (GetItemList.Contains(_item))
        {
            GetItemList.Remove(_item);
        }

        InventoryUI.UpdateInventoryUI();
    }
}
