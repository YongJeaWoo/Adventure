using UnityEngine;

public class TrailEffect : MonoBehaviour
{
    [Header ("공격 트레일")]
    [SerializeField] private TrailRenderer attackTrail;
    [Header("회피 트레일")]
    [SerializeField] private TrailRenderer dodgeTrail;

    public void ShowAttackTrailEvent()
    {
        attackTrail.enabled = true;
    }

    public void HideAttackTrailEvent()
    {
        attackTrail.enabled = false;
    }

    public void ShowDodgeTrailEvent()
    {
        dodgeTrail.enabled = true;
    }

    public void HideDodgeTrailEvent()
    {
        dodgeTrail.enabled = false;
    }
}
