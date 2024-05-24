using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Item/Consumable")]
public class ConsumableItem : Item
{
    [Header("�Ҹ� ������ Ÿ��")]
    [SerializeField] private EnumData.E_ConsumerType consumerType;

    public EnumData.E_ConsumerType ConsumerType { get => consumerType; set => consumerType = value; }
}
