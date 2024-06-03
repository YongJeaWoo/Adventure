using UnityEngine;

public class VerticalAttack : QSkillComponent
{
    [SerializeField] private GameObject groundEffectPrefab;
    [SerializeField] private Transform effectTransform;

    [Header("�ٴ� ����ġ�� �Ҹ�")]
    [SerializeField] private AudioClip groundClip;

    public void GroundEffectEvent()
    {
        Instantiate(groundEffectPrefab, effectTransform.position, Quaternion.identity);
        AudioManager.instance.PlayEffectSound(groundClip);
    }
}
