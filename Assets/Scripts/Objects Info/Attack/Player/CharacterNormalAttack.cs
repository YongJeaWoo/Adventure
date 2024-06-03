using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterNormalAttack : BaseAttack
{
    [Header("공격 소리")]
    [SerializeField] private AudioClip attackClip;
    [Header("바닥 내리치는 소리")]
    [SerializeField] protected AudioClip groundClip;
    [Header("바닥 내리칠 때 나는 이팩트")]
    [SerializeField] private GameObject groundEffectPrefab;

    private WaitForSeconds attackInputWait;
    private Coroutine attackWaitCoroutine;

    public bool isAttack;

    private float attackInputDuration = 0.05f;

    private int hashMeleeAttack = Animator.StringToHash("MeleeAttack");
    private int hashStateTime = Animator.StringToHash("StateTime");

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        attackInputWait = new WaitForSeconds(attackInputDuration);
    }

    private void Update()
    {
        NormalAttack();
    }

    private void FixedUpdate()
    {
        AnimationPlay();
    }

    private void NormalAttack()
    {
        if (CharacterHealth.isDie || EventSystem.current.IsPointerOverGameObject()) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (attackWaitCoroutine != null)
            {
                StopCoroutine(attackWaitCoroutine);
            }

            attackWaitCoroutine = StartCoroutine(AttackWait());
        }
    }

    private void AnimationPlay()
    {
        animator.SetFloat(hashStateTime, Mathf.Repeat(animator.GetCurrentAnimatorStateInfo(0).normalizedTime, 1f));
        animator.ResetTrigger(hashMeleeAttack);

        if (isAttack)
        {
            animator.SetTrigger(hashMeleeAttack);
        }
    }

    public void AnimationEffectSoundEvent()
    {
        AudioManager.instance.PlayEffectSound(attackClip);
    }

    public void GroundEffectSoundEvent()
    {
        AudioManager.instance.PlayEffectSound(groundClip);
        Instantiate(groundEffectPrefab, attackHitPoint.position, Quaternion.identity);
    }

    private IEnumerator AttackWait()
    {
        isAttack = true;
        yield return attackInputWait;
        isAttack = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackHitPoint.position, attackRange);
    }
}
