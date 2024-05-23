using UnityEngine;

// ��ų ���
// �÷��̾ Ű�� �������� �ľǸ�
public class ESkillComponent : CharacterSkillAttack
{
    [Header("��ų ������")]
    [SerializeField] protected SkillData eSkillSOJ;

    protected override void Awake()
    {
        base.Awake();
        keyCode = eSkillSOJ.KeyCode;
        skillTimer = eSkillSOJ.SkillCoolTime;
        coolTime = skillTimer;
    }
}
