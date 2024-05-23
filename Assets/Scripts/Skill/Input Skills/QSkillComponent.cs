using UnityEngine;

// �÷��̾ Ű�� ���������� ���� �ľǸ�
public class QSkillComponent : CharacterSkillAttack
{
    [Header("��ų ������")]
    [SerializeField] protected SkillData qSkillSOJ;
    
    protected override void Awake()
    {
        base.Awake();
        keyCode = qSkillSOJ.KeyCode;
        skillTimer = qSkillSOJ.SkillCoolTime;
        coolTime = skillTimer;
    }
}
