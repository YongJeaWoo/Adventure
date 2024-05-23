using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Item/Consumable")]
public class ConsumableItem : Item
{
    [Header("�Ҹ� ������ Ÿ��")]
    [SerializeField] private EnumData.E_ConsumerType consumerType;
    [Header("������ ��� ��ġ")]
    [SerializeField] private int value;

    public EnumData.E_ConsumerType ConsumerType { get => consumerType; set => consumerType = value; }
    public int Value { get => value; set => this.value = value; }
}
