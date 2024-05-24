using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Item/Consumable")]
public class ConsumableItem : Item
{
    [Header("�Ҹ� ������ Ÿ��")]
    [SerializeField] private EnumData.E_ConsumerType consumerType;
    [Header("������ ��� ��ġ")]
    [SerializeField] private int value;
    [Header("������ ��� �� ���� �̸�")]
    [SerializeField] private string onceOpenName;
    [Header("������ ��� �� ���� ����")]
    [SerializeField] private string onceOpenExplain;

    private bool onceOpen;

    public EnumData.E_ConsumerType ConsumerType { get => consumerType; set => consumerType = value; }
    public int Value { get => value; set => this.value = value; }
    public bool OnceOpen { get => onceOpen; set => onceOpen = value; }
    public string OnceOpenName { get => onceOpenName; set => onceOpenName = value; }
    public string OnceOpenExplain { get => onceOpenExplain; set => onceOpenExplain = value; }
}
