using UnityEngine;

public abstract class Item : ScriptableObject
{
    [Header ("아이템 타입")]
    [SerializeField] private EnumData.E_ItemType type;
    [Header("아이템 아이디")]
    [SerializeField] private int itemId;
    [Header("아이템 이름")]
    [SerializeField] private string itemName;
    [Header("아이템 설명")]
    [SerializeField] private string itemExplain;
    [Header("아이템 아이콘 이미지")]
    [SerializeField] private Sprite itemIconImage;
    [Header("아이템 갯수")]
    [SerializeField] private int itemCount;

    public EnumData.E_ItemType Type { get => type; set => type = value; }
    public int ItemId { get => itemId; set => itemId = value; }
    public string ItemName { get => itemName; set => itemName = value; }
    public string ItemExplain { get => itemExplain; set => itemExplain = value; }
    public Sprite ItemIconImage { get => itemIconImage; set => itemIconImage = value; }
    public int ItemCount { get => itemCount; set => itemCount = value; }

    public Item Clone()
    {
        Item newItem = Instantiate(this);
        return newItem;
    }
}
