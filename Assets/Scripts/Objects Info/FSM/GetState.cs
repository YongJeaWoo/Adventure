using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class GetState<TEnum, TState, TController> : MonoBehaviour
    where TEnum : Enum
    where TState : GetState<TEnum, TState, TController>
    where TController : FSMController<TEnum, TState, TController>
{
    protected Animator animator;
    protected NavMeshAgent agent;
    protected BaseHealth health;
    protected TController fsm;

    protected string AnimationName = "State";

    protected virtual void Awake()
    {
        GetComponents();
    }

    private void GetComponents()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<BaseHealth>();
        fsm = GetComponent<TController>();
    }

    public abstract void EnterState(TEnum state);

    public abstract void UpdateState();
    public abstract void ExitState();
}
