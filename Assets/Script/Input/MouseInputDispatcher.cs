using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInputDispatcher : InputDispatcher
{
    public event System.Action<Vector2> OnMouseInputOccurred;

    public MouseInputDispatcher(InputActionType type)
    {
        if(!InputActionGroups.MouseTypes.Contains(type))
            throw new ArgumentException("Type is not mouse input action, need to check");

        Handle = InputRegistry.Instance().GetInputHandle(type);
        Type = type;
    }
    protected override void OnPerformed(InputAction.CallbackContext context)
    {
        OnMouseInputOccurred?.Invoke(Mouse.current.position.ReadValue());
    }
}