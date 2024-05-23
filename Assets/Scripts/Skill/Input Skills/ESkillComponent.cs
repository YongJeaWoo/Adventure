using UnityEngine;

// 스킬 기능
// 플레이어가 키를 눌렀는지 파악만
public class ESkillComponent : CharacterSkillAttack
{
    [Header("스킬 데이터")]
    [SerializeField] protected SkillData eSkillSOJ;

    protected override void Awake()
    {
        base.Awake();
        keyCode = eSkillSOJ.KeyCode;
        skillTimer = eSkillSOJ.SkillCoolTime;
        coolTime = skillTimer;
    }
}
