using System.Diagnostics;
using UnityEngine.InputSystem;
using UnityEngine;

public abstract class InputDispatcher
{
    protected InputHandle Handle;
    protected InputActionType Type = InputActionType.eNone;

    private bool bBound = false;

    public void Enable()
    {
        if(!bBound)
        {
            Handle.Enable();
            Handle.Input.performed += OnPerformed;   
            bBound = true;
        }
    }

    public abstract void Update();

    public void Disable()
    {
        if(bBound)
        {
            Handle.Input.performed -= OnPerformed;
            Handle.Disable();   
            bBound = false;
        }
    }

    protected abstract void OnPerformed(InputAction.CallbackContext context);
}