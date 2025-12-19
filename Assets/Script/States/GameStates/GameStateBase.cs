using UnityEngine;

public abstract class GameStateBase : StateBase
{
    public GameStateType StateType {get; protected set; } = GameStateType.eNone;

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
