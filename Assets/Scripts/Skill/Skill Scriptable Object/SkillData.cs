using UnityEngine;

[CreateAssetMenu(menuName = "SkillData/SkillData Data")]
public class SkillData : ScriptableObject
{
    [Header ("������")]
    [SerializeField] private Sprite iconSprite;
    [Header("��Ÿ��")]
    [SerializeField] private float skillCoolTime;
    [Header("�Է� Ű")]
    [SerializeField] private KeyCode keyCode;

    public Sprite IconSprite => iconSprite;
    public float SkillCoolTime => skillCoolTime;
    public KeyCode KeyCode => keyCode;
}
