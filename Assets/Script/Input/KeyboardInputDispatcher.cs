using System;
using UnityEngine.InputSystem;

public class KeyboardInputDispatcher : InputDispatcher
{
     public event System.Action OnKeyboardInputOccurred;

    public KeyboardInputDispatcher(InputActionType type)
    {
        if(!InputActionGroups.KeyboardTypes.Contains(type))
            throw new ArgumentException("Type is not keyboard input action, need to check");

        Handle = InputRegistry.Instance().GetInputHandle(type);
        Type = type;
    }

    protected override void OnPerformed(InputAction.CallbackContext context)
    {
        OnKeyboardInputOccurred?.Invoke();
    }
}