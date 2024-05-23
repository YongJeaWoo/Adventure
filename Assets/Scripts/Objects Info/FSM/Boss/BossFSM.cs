public enum E_DragonState
{
    Sleep,
    Warning,
    Idle,
    Thinking,
    FaceAttack,
    TailAttack,
    FireAttack,
    Fly,
    FlyAttack,
    Land,
    Hit,
    Death
}

public class BossFSM : FSMController<E_DragonState, BossState, BossFSM>
{
    protected override void Start()
    {
        base.Start();
        TransitionToState(E_DragonState.Sleep);
    }
}
