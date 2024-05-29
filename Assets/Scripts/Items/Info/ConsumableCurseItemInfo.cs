using System.Collections.Generic;
using UnityEngine;

public class ConsumableCurseItemInfo : MonoBehaviour
{
    [Header("아이템 사용 후 사용될 이름")]
    private string afterUseItemName;
    public string AfterUseItemName { get => afterUseItemName; set => afterUseItemName = value; }

    [Header("아이템 사용 후 사용될 설명")]
    private string afterUseItemExplain;
    public string AfterUseItemExplain { get => afterUseItemExplain; set => afterUseItemExplain = value; }

    private static Dictionary<int, bool> itemOpenstatus = new Dictionary<int, bool>();

    public (string, string) GetUseItemMessage(ConsumableItem _item)
    {
        int itemId = _item.ItemId;

        AfterUseItemName = _item.OnceName;
        AfterUseItemExplain = _item.OnceExplain;

        if (IsItemOpen(itemId))
        {
            return (AfterUseItemName, AfterUseItemExplain);
        }
        else
        {
            MarkItemAsUsed(itemId);
            return (_item.ItemName, _item.ItemExplain);
        }
    }

    public bool IsItemOpen(int _itemId)
    {
        return itemOpenstatus.ContainsKey(_itemId) && itemOpenstatus[_itemId];
    }

    public void MarkItemAsUsed(int  _itemId)
    {
        itemOpenstatus[_itemId] = true;
    }
}
