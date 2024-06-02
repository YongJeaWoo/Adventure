using System.Collections;
using UnityEngine;

public class TrailEffect : MonoBehaviour
{
    [Header ("공격 트레일")]
    [SerializeField] private TrailRenderer attackTrail;
    [Header("회피 트레일")]
    [SerializeField] private TrailRenderer dodgeTrail;

    private Coroutine attackTrailCoroutine;
    private Coroutine dodgeTrailCoroutine;

    private void Awake()
    {
        if (attackTrail != null) attackTrail.enabled = false;
        if (dodgeTrail != null) dodgeTrail.enabled = false;
    }

    public void ShowAttackTrailEvent()
    {
        if (attackTrailCoroutine != null) StopCoroutine(attackTrailCoroutine);

        attackTrail.enabled = true;
        attackTrailCoroutine = StartCoroutine(DisableTrail(attackTrail));
    }

    public void HideAttackTrailEvent()
    {
        attackTrail.enabled = false;
        if (attackTrailCoroutine != null)
            StopCoroutine(attackTrailCoroutine);
    }

    public void ShowDodgeTrailEvent()
    {
        if (dodgeTrailCoroutine != null)
            StopCoroutine(dodgeTrailCoroutine);

        dodgeTrail.enabled = true;
        dodgeTrailCoroutine = StartCoroutine(DisableTrail(dodgeTrail));
    }

    public void HideDodgeTrailEvent()
    {
        dodgeTrail.enabled = false;
        if (dodgeTrailCoroutine != null)
            StopCoroutine(dodgeTrailCoroutine);
    }

    private IEnumerator DisableTrail(TrailRenderer trail)
    {
        float duration = 1f;
        yield return new WaitForSeconds(duration);
        trail.enabled = false;
    }
}
