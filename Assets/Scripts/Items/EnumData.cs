using UnityEngine;

public class EnumData : MonoBehaviour
{
    public enum E_SoundType
    {
        Master,
        BGM,
        Battle,
        Effect
    }

    public enum E_ItemType
    {
        Consumable
    }

    public enum E_ConsumerType
    {
        HpUp,           // 체력 증가
        Curse,          // 체력 감소 (저주)
        BuffAttack  // 공격력 증가
    }
}
