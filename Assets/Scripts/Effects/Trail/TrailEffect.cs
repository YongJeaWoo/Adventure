using UnityEngine;

public class TrailEffect : MonoBehaviour
{
    [Header ("���� Ʈ����")]
    [SerializeField] private TrailRenderer attackTrail;
    [Header("ȸ�� Ʈ����")]
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
