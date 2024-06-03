using UnityEngine;

public class VerticalAttack : QSkillComponent
{
    [SerializeField] private GameObject groundEffectPrefab;
    [SerializeField] private Transform effectTransform;

    [Header("바닥 내리치는 소리")]
    [SerializeField] private AudioClip groundClip;

    public void GroundEffectEvent()
    {
        Instantiate(groundEffectPrefab, effectTransform.position, Quaternion.identity);
        AudioManager.instance.PlayEffectSound(groundClip);
    }
}
