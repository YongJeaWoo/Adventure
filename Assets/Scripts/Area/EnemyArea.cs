using UnityEngine;

public abstract class EnemyArea : MonoBehaviour
{
    [Header("지역별 전투 노래")]
    [SerializeField] private AudioClip battleClip;
    public AudioClip BattleClip { get => battleClip; }
    [Header("재생성 시간")]
    [SerializeField] protected float respawnTimer;

    protected abstract void Respawn();
    protected abstract void Spawn();
}
