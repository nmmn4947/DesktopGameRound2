using UnityEngine;

public interface StateBase
{
    //public GameStateType StateType {get; protected set; } = GameStateType.eNone;

    public void Enter();
    public void Update();
    public void Exit();
}
