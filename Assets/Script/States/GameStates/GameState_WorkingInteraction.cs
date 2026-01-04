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

            InputActionType.eKeyboardWHold,
            InputActionType.eKeyboardAHold,
            InputActionType.eKeyboardSHold,
            InputActionType.eKeyboardDHold,
        };

        InputManager.Instance().SetInputDispatcherSet(dispatcherType);
        FocusedObjectManager.Instance()?.Enable();
    }

    public override void Exit() => FocusedObjectManager.Instance()?.Disable();
}