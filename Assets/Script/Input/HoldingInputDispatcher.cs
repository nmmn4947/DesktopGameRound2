using System;
using UnityEngine.InputSystem;

public sealed class HoldingInputDispatcher : InputDispatcher
{
    private bool bHolding = false;

    public HoldingInputDispatcher(InputActionType type)
        :base(type)
    {   }

    public override void Update()
    {
        if(bHolding)
            TriggerInput();
    }

    public bool IsHolding() => bHolding;

    protected override bool IsValidInputActionType(InputActionType type) => InputActionGroups.HoldingTypes.Contains(type);

    protected override void OnPerformed(InputAction.CallbackContext context)
    {
        bHolding = !bHolding;

        if(bHolding)
            OnEntered(context);

        base.OnPerformed(context);
        
        if(!bHolding)
            OnExited(context);           
    }
}