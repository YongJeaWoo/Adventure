using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Item/Consumable")]
public class ConsumableItem : Item
{
    [Header("소모성 아이템 타입")]
    [SerializeField] private EnumData.E_ConsumerType consumerType;
    [Header("아이템 사용 수치")]
    [SerializeField] private int value;
    [Header("아이템 사용 후 갱신 이름")]
    [SerializeField] private string onceOpenName;
    [Header("아이템 사용 후 갱신 설명")]
    [SerializeField] private string onceOpenExplain;

    private bool onceOpen;

    public EnumData.E_ConsumerType ConsumerType { get => consumerType; set => consumerType = value; }
    public int Value { get => value; set => this.value = value; }
    public bool OnceOpen { get => onceOpen; set => onceOpen = value; }
    public string OnceOpenName { get => onceOpenName; set => onceOpenName = value; }
    public string OnceOpenExplain { get => onceOpenExplain; set => onceOpenExplain = value; }
}
