using System;
using UnityEngine;

public abstract class FSMController<TEnum, TState, TController> : MonoBehaviour
    where TEnum : Enum
    where TState : GetState<TEnum, TState, TController>
    where TController : FSMController<TEnum, TState, TController>
{
    protected TState currentState;
    public TState CurrentState { get => currentState; set => currentState = value; }

    [Header("상태 패턴")]
    [SerializeField] protected TState[] myStates;
    public TState[] MyStates { get => myStates; set => myStates = value; }

    protected GameObject player;

    [Header("UI용 데이터")]
    [SerializeField] private BossData bossDataSOJ;
    public BossData BossDataSOJ { get => bossDataSOJ; }
    [Header("지역 감지 범위")]
    [SerializeField] protected float detectDistance;
    [Header("공격 대상 이름")]
    [SerializeField] protected string targetName;
    public string TargetName { get => targetName; set => targetName = value; }

    private bool playerDetected = false;
    protected bool PlayerDetected { get => playerDetected; set => playerDetected = value; }
    protected bool isAlive = false;
    public bool IsAlive { get => isAlive; set => isAlive = value; }

    protected virtual void Start()
    {
        player = PlayerManager.instance.GetPlayer();
    }

    protected virtual void Update()
    {
        CurrentState?.UpdateState();
    }

    public void TransitionToState(TEnum state)
    {
        CurrentState?.ExitState();
        CurrentState = MyStates[Convert.ToInt32(state)];
        CurrentState.EnterState(state);
    }

    public void SetPlayer(GameObject newPlayer)
    {
        player = newPlayer;
    }

    public float GetPlayerDistance() => Vector3.Distance(transform.position,
        player.transform.position);
    public GameObject GetPlayer() => player;
    public TState GetCurrentState() => CurrentState;
    public TState[] GetCurrentStates() => MyStates;
}
