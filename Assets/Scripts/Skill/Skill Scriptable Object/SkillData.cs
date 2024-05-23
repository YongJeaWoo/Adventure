using UnityEngine;

[CreateAssetMenu(menuName = "SkillData/SkillData Data")]
public class SkillData : ScriptableObject
{
    [Header ("아이콘")]
    [SerializeField] private Sprite iconSprite;
    [Header("쿨타임")]
    [SerializeField] private float skillCoolTime;
    [Header("입력 키")]
    [SerializeField] private KeyCode keyCode;

    public Sprite IconSprite => iconSprite;
    public float SkillCoolTime => skillCoolTime;
    public KeyCode KeyCode => keyCode;
}
