using System.Collections.Generic;
using UnityEngine;

public abstract class GameStateBase : StateBase
{
    public GameStateType StateType {get; protected set; } = GameStateType.eNone;
    public List<InputActionType> dispatcherType = null;
    public abstract void Enter();
    public virtual void Update() 
    {   }
    public virtual void Exit() 
    {   }
    public virtual void Dispose()
    {
        if(dispatcherType != null)
        {
            dispatcherType.Clear();
            dispatcherType = null;
        }
    }
}
