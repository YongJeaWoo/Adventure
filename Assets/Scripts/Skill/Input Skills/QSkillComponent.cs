using UnityEngine;

// 플레이어가 키를 눌렀는지에 대한 파악만
public class QSkillComponent : CharacterSkillAttack
{
    [Header("스킬 데이터")]
    [SerializeField] protected SkillData qSkillSOJ;
    
    protected override void Awake()
    {
        base.Awake();
        keyCode = qSkillSOJ.KeyCode;
        skillTimer = qSkillSOJ.SkillCoolTime;
        coolTime = skillTimer;
    }
}
