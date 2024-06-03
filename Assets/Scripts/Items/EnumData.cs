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
        HpUp,           // ü�� ����
        Curse,          // ü�� ���� (����)
        BuffAttack  // ���ݷ� ����
    }
}
