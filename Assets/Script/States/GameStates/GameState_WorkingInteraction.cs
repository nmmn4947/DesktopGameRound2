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
            InputActionType.eLeftMousePressed,  //  for seting focused object   - generic
            InputActionType.eLeftMouseTapped,   //  for earning coin            - focused object (character state)
            InputActionType.eLeftMouseHold,     //  for following               - focused object (character state)
        };

        FocusedObjectManager.Instance()?.Enable();

        //InputDispatcherSet dispatchers = new InputDispatcherSet_WorkingIdleState();

        //InputManager.Instance().ChangeInputDispatcherSet(dispatchers);
    }
    public override void Update()
    {   }

    public override void Exit()
    {
        FocusedObjectManager.Instance()?.Disable();
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}