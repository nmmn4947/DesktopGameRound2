using System.Collections.Generic;
using UnityEngine;

public class GameState_WorkingIdle : GameStateBase
{
    public GameState_WorkingIdle()
    { StateType = GameStateType.eWorking_Idle; }
    
    public override void Enter()
    {
        // just initialize the list of dispatcher type
        // - the game state manager automatically change the input dispatcher list
        dispatcherType = new List<InputActionType>
        {   };
    }
    public override void Update()
    {
    }
    public override void Exit()
    {
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}