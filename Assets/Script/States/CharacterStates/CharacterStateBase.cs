using UnityEngine;

public abstract class CharacterStateBase : StateBase
{
    public CharacterStateType StateType {get; protected set; } = CharacterStateType.eNone;
    protected GameObject Owner = null;

    public CharacterStateBase(GameObject Object)
    {
        Owner = Object;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
    public virtual void Dispose() => Owner = null;
}
