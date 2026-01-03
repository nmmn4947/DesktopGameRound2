using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDispatcher
{        
    public event Action OnInputEntered;
    public event Action OnInputOccurred;
    public event Action OnInputExited;

    protected InputHandle Handle;
    public InputActionType Type = InputActionType.eNone;

    private bool bBound = false;
    public int BindCount {get; protected set; }

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

    public void Bind(Action enterFunction, Action boundFunction, Action exitFunction)
    {
        if(enterFunction == null && boundFunction == null && exitFunction == null)
            return;

        if(enterFunction != null)
            OnInputEntered += enterFunction;

        if(boundFunction != null)
            OnInputOccurred += boundFunction;

        if(exitFunction != null)
            OnInputExited += exitFunction;

        BindCount++;
    }
    
    public void Unbind(Action enterFunction, Action boundFunction, Action exitFunction)
    {
        if(enterFunction == null && boundFunction == null && exitFunction == null)
            return;

        if(enterFunction != null)
            OnInputEntered -= enterFunction;

        if(boundFunction != null)
            OnInputOccurred -= boundFunction;

        if(exitFunction != null)
            OnInputExited -= exitFunction;

        BindCount--;
    }

    protected virtual void OnPerformed(InputAction.CallbackContext context) => TriggerInput();    

    protected virtual void OnEntered(InputAction.CallbackContext context) => OnInputEntered?.Invoke();    

    protected virtual void OnExited(InputAction.CallbackContext context) => OnInputExited?.Invoke();    

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