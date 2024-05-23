using UnityEngine;

[CreateAssetMenu(fileName = "Boss", menuName = "Boss/BossData")]
public class BossData : ScriptableObject
{
    [Header("보스 설명")]
    [SerializeField] private string explainText;
    public string ExplainText { get => explainText; }

    [Header("데미지 분배")]
    [SerializeField] private int faceDamage;
    [SerializeField] private int tailDamage;
    [SerializeField] private int flyDamage;
    [SerializeField] private int fireDamage;
    public int FaceDamage { get => faceDamage; set => faceDamage = value; }
    public int TailDamage { get => tailDamage; set => tailDamage = value; }
    public int FlyDamage { get => flyDamage; set => flyDamage = value; }
    public int FireDamage { get => fireDamage; set => fireDamage = value; }
}
