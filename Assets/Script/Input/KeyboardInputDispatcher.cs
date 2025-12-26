using System;
using UnityEngine.InputSystem;

public class KeyboardInputDispatcher : InputDispatcher
{
    public event Action OnKeyboardInputOccurred;

    public KeyboardInputDispatcher(InputActionType type)
    {
        if(!InputActionGroups.KeyboardTypes.Contains(type) && 
            !InputActionGroups.KeyboardHoldingTypes.Contains(type))
            throw new ArgumentException("Type is not keyboard input action, need to check");

        Handle = InputRegistry.Instance().GetInputHandle(type);
        Type = type;
    }

    public override void Update()
    {   }

    protected override void OnPerformed(InputAction.CallbackContext context)
    {
        TriggerKeyboardInput();
    }
    

    protected void TriggerKeyboardInput() => OnKeyboardInputOccurred?.Invoke();
}