using UnityEditor;
using UnityEngine;

public class WorkingIdleState : CharacterStateBase
{
    private InputHandleSet HandleSet;

    public WorkingIdleState(GameObject owner)
        :base(owner)
    { StateType = CharacterStateType.eWorkingIdle; }

    public override void Enter()
    {
        HandleSet = new InputHandleSetWorkingIdleState();

        InputManager.Instance().ChangeInputHandleSet(HandleSet);

        if(HandleSet.HoldingDispatchers.TryGetValue(InputActionType.eKeyboardWHolding, out InputDispatcher dispatcher))
        {
            if(dispatcher is KeyboardHoldingInputDispatcher keyboardDispatcher)
            {
                Debug.Log("Bind with keyboard dispatcher");
                keyboardDispatcher.OnKeyboardInputOccurred += DebugLog;
            }
        }
    }
    
    public override void Update()
    {
        
    }
    public override void Exit()
    {
        
    }

    private void DebugLog()
    {
        Debug.Log("Pressed W key");
    }
}