using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

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

        if(HandleSet.Dispatchers.TryGetValue(InputActionType.eKeyboardWPressed, out InputDispatcher dispatcher))
        {
            if(dispatcher is KeyboardInputDispatcher keyboardDispatcher)
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