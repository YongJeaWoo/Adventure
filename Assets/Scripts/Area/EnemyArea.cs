using UnityEngine;

public abstract class EnemyArea : ItemDrop
{
    [Header("������ ���� �뷡")]
    [SerializeField] private AudioClip battleClip;
    public AudioClip BattleClip { get => battleClip; }
    [Header("����� �ð�")]
    [SerializeField] protected float respawnTimer;

    protected abstract void Respawn();
    protected abstract void Spawn();
}
