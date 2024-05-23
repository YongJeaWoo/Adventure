using UnityEngine;

// 플레이어 공격 수행
public class CharacterAttackController : MonoBehaviour
{
    public enum E_Type
    {
        HorizontalSkill,
        VerticalSkill
    }

    public bool onSkill;

    [SerializeField] private BaseAttack normalAttack;
    public BaseAttack NormalAttack { get => normalAttack; set => normalAttack = value; }

    [Space(8)]
    [SerializeField] private string attackLayerName;
    public string AttackLayerName { get => attackLayerName; set => attackLayerName = value; }

    [SerializeField] private KeyCode[] skillKeyCode;
    public KeyCode[] SkillKeyCode { get => skillKeyCode; set => skillKeyCode = value; }

    [SerializeField] private CharacterSkillAttack[] characterAttack;

    public void OnNormalAttackAnimationEvent()
    {
        NormalAttack.Attack(AttackLayerName);
    }

    public void HorizontalSkillAttack()
    {
        characterAttack[(int)E_Type.HorizontalSkill].Attack(AttackLayerName);
    }

    public void VerticalSkillAttack()
    {
        characterAttack[(int)E_Type.VerticalSkill].Attack(AttackLayerName);
    }
}
