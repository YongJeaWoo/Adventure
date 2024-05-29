using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Item/Consumable")]
public class ConsumableItem : Item
{
    [Header("소모성 아이템 타입")]
    [SerializeField] private EnumData.E_ConsumerType consumerType;
    [Header("아이템 사용 수치")]
    [SerializeField] private int value;
    [Header("아이템 한번 열린 후의 이름")]
    [SerializeField] private string onceName;
    [Header("아이템 한번 열린 후의 설명")]
    [SerializeField] private string onceExplain;

    public EnumData.E_ConsumerType ConsumerType { get => consumerType; set => consumerType = value; }
    public int Value { get => value; set => this.value = value; }
    public string OnceName { get => onceName; set => onceName = value; }
    public string OnceExplain { get => onceExplain; set => onceExplain = value; }
}
