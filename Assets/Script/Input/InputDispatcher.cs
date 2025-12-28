using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDispatcher
{    
    public event Action OnInputOccurred;

    protected InputHandle Handle;
    public InputActionType Type = InputActionType.eNone;

    private bool bBound = false;

    public InputDispatcher(InputActionType type)
    {
        if(!IsValidInputActionType(type))
            throw new ArgumentException("Type is not valid input action, need to check");

        Handle = InputRegistry.Instance().GetInputHandle(type);
        Type = type;
    }

    public void Enable()
    {
        if(!bBound)
        {
            Handle.Enable();
            Handle.Input.performed += OnPerformed;   
            bBound = true;
        }
    }

    public bool IsBound() => bBound;

    protected virtual bool IsValidInputActionType(InputActionType type) => InputActionGroups.Types.Contains(type);

    public virtual void Update(){}

    public void Disable()
    {
        if(bBound)
        {
            Handle.Input.performed -= OnPerformed;
            Handle.Disable();   
            bBound = false;
        }
    }

    protected virtual void OnPerformed(InputAction.CallbackContext context) => TriggerInput();    

    protected void TriggerInput() => OnInputOccurred?.Invoke();

    public bool Dispose()
    {
        if(Handle.Dispose())
        {
            OnInputOccurred = null;
            return true;   
        }

        return false;
    }
}