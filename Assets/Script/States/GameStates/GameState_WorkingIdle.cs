using System.Collections.Generic;
using UnityEngine;

public class GameState_WorkingIdle : GameStateBase
{
    public GameState_WorkingIdle()
    { StateType = GameStateType.eWorking_Idle; }
    
    public override void Enter()
    {
        dispatcherType = new List<InputActionType>
        {
            InputActionType.eKeyboardWPressed
        };
        //InputDispatcherSet dispatchers = new InputDispatcherSet_WorkingIdleState();

        //InputManager.Instance().ChangeInputDispatcherSet(dispatchers);
    }
    public override void Update()
    {
    }
    public override void Exit()
    {
        //InputManager.Instance().ChangeInputDispatcherSet(null);
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}