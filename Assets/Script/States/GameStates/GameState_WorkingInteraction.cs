using System.Collections.Generic;
using UnityEngine;

public class GameState_WorkingInteraction : GameStateBase
{
    public GameState_WorkingInteraction()
    { StateType = GameStateType.eWorking_Interaction; }
    
    public override void Enter()
    {
        Debug.Log("Enter GameState Working Interaction");

        dispatcherType = new List<InputActionType>
        {
            InputActionType.eLeftMouseHolding,

            InputActionType.eKeyboardWHolding,
            InputActionType.eKeyboardAHolding,
            InputActionType.eKeyboardSHolding,
            InputActionType.eKeyboardDHolding,
        };

        //InputDispatcherSet dispatchers = new InputDispatcherSet_WorkingIdleState();

        //InputManager.Instance().ChangeInputDispatcherSet(dispatchers);
    }
    public override void Update()
    {   }

    public override void Exit()
    {   }

    public override void Dispose()
    {
        base.Dispose();
    }
}