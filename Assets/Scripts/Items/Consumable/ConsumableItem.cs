using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Item/Consumable")]
public class ConsumableItem : Item
{
    [Header("�Ҹ� ������ Ÿ��")]
    [SerializeField] private EnumData.E_ConsumerType consumerType;
    [Header("������ ��� ��ġ")]
    [SerializeField] private int value;
    [Header("������ �ѹ� ���� ���� �̸�")]
    [SerializeField] private string onceName;
    [Header("������ �ѹ� ���� ���� ����")]
    [SerializeField] private string onceExplain;

    public EnumData.E_ConsumerType ConsumerType { get => consumerType; set => consumerType = value; }
    public int Value { get => value; set => this.value = value; }
    public string OnceName { get => onceName; set => onceName = value; }
    public string OnceExplain { get => onceExplain; set => onceExplain = value; }
}
