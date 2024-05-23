using System.Collections;
using UnityEngine;

// 플레이어 공격 기능 담당
public class CharacterSkillAttack : BaseAttack
{
    [Header("공격 소리")]
    [SerializeField] protected AudioClip attackClip;

    private SkillTimerImage skillTimerImage;

    protected CharacterMovement movement;
    protected CharacterAttackController attackController;

    protected KeyCode keyCode;
    
    [SerializeField] protected string skillName;

    protected float skillTimer;
    protected float timer;

    protected bool isSkill;
    protected float coolTime;

    protected override void Awake()
    {
        base.Awake();
        movement = GetComponent<CharacterMovement>();
        attackController = GetComponent<CharacterAttackController>();
    }

    protected virtual void Start()
    {
        skillTimerImage = GameObject.Find(skillName + "Image").GetComponent<SkillTimerImage>();
    }

    private void Update()
    {
        SkillCoolCal();
    }

    protected virtual void SkillCoolCal()
    {
        if (timer > 0) return;

        if (CharacterHealth.isDie || movement.IsJump) return;

        if (attackController.onSkill) return;

        if (isSkill) return;

        if (Input.GetKeyDown(keyCode))
        {
            skillTimerImage.StartTimer();
            StartCoroutine(WaitCoolTime());
            animator.SetTrigger(skillName);
        }
    }

    public override Collider[] Attack(string targetName, bool isKnockBack = false)
    {
        return base.Attack(targetName, isKnockBack);
    }

    protected IEnumerator WaitCoolTime()
    {
        isSkill = true;

        movement.enabled = false;

        yield return new WaitForSeconds(coolTime);
        
        isSkill = false;
    }

    public void CharacterMovement()
    {
        movement.enabled = true;
    }

    public void EffectAnimationEvent()
    {
        AudioManager.instance.PlayerEffectSound(attackClip);
    }
}
