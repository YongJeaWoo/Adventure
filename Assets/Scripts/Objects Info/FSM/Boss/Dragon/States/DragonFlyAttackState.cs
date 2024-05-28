using System.Collections;
using UnityEngine;

public class DragonFlyAttackState : BossAttackAble
{
    private Collider col;

    protected override void Awake()
    {
        base.Awake();
        col = GetComponent<Collider>();
    }

    private void Start()
    {
        SetDamage(fsm.BossDataSOJ.FlyDamage);
    }

    public override void EnterState(E_DragonState state)
    {
        animator.SetInteger(AnimationName, (int)state);
        StartCoroutine(CurveAttack(transform.position, fsm.GetPlayer().transform.position));
    }

    public override void UpdateState()
    {
        
    }

    public override void ExitState()
    {
        
    }


    private IEnumerator CurveAttack(Vector3 startPosition, Vector3 endPosition)
    {
        LookAtTarget(fsm.GetPlayer().transform.position);

        // �巡���� �÷��̾ �հ� ������ ��ü ��� ���
        Vector3 attackDirection = (endPosition - startPosition).normalized;
        Vector3 passThroughTarget = endPosition + attackDirection;

        float attackDuration = 2.0f; // ���� ���� �ð�
        float returnDuration = 2.0f; // ���� ���� �ð�
        float elapsedTime = 0f;

        // �÷��̾� ��ġ�� ���� ����
        while (elapsedTime < attackDuration)
        {
            float t = elapsedTime / attackDuration;
            transform.position = Vector3.Lerp(startPosition, passThroughTarget, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = passThroughTarget;

        // ���� ��ġ�� ���ư���
        LookAtTarget(startPosition);
        elapsedTime = 0f;
        while (elapsedTime < returnDuration)
        {
            float t = elapsedTime / returnDuration;
            transform.position = Vector3.Lerp(passThroughTarget, startPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = startPosition;

        fsm.TransitionToState(E_DragonState.Land);
    }

    public void ToggleCollider(bool _isOn)
    {
        _isOn = !_isOn;
        col.enabled = _isOn;
    }
}
