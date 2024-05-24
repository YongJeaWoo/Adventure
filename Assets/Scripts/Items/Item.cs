using UnityEngine;

public abstract class Item : ScriptableObject
{
    [Header ("������ Ÿ��")]
    [SerializeField] private EnumData.E_ItemType type;
    [Header("������ ���̵�")]
    [SerializeField] private int itemId;
    [Header("������ �̸�")]
    [SerializeField] private string itemName;
    [Header("������ ����")]
    [SerializeField] private string itemExplain;
    [Header("������ ������ �̹���")]
    [SerializeField] private Sprite itemIconImage;
    [Header("������ ����")]
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
