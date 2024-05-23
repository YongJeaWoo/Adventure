using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Item/Consumable")]
public class ConsumableItem : Item
{
    [Header("소모성 아이템 타입")]
    [SerializeField] private EnumData.E_ConsumerType consumerType;
    [Header("아이템 사용 수치")]
    [SerializeField] private int value;

    public EnumData.E_ConsumerType ConsumerType { get => consumerType; set => consumerType = value; }
    public int Value { get => value; set => this.value = value; }
}
