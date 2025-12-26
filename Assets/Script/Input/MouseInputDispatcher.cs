using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInputDispatcher : InputDispatcher
{
    public event Action<Vector2> OnMouseInputOccurred;

    public MouseInputDispatcher(InputActionType type)
    {
        if(!InputActionGroups.MouseTypes.Contains(type) && 
            !InputActionGroups.MouseHoldingTypes.Contains(type))
            throw new ArgumentException("Type is not mouse input action, need to check");

        Handle = InputRegistry.Instance().GetInputHandle(type);
        Type = type;
    }
    public override void Update()
    {   }

    protected override void OnPerformed(InputAction.CallbackContext context)
    {
        TriggerMouseInput();
    }

    protected void TriggerMouseInput() => OnMouseInputOccurred?.Invoke(Mouse.current.position.ReadValue());
}