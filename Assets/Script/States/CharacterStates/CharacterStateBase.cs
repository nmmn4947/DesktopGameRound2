using UnityEngine;

public abstract class CharacterStateBase : StateBase
{
    public CharacterStateType StateType {get; protected set; } = CharacterStateType.eNone;

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
