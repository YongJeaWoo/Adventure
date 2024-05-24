using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Item/Consumable")]
public class ConsumableItem : Item
{
    [Header("소모성 아이템 타입")]
    [SerializeField] private EnumData.E_ConsumerType consumerType;

    public EnumData.E_ConsumerType ConsumerType { get => consumerType; set => consumerType = value; }
}
