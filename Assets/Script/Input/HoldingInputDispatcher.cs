using UnityEngine.InputSystem;

public sealed class HoldingInputDispatcher : InputDispatcher
{
    private bool IsHolding = false;

    public HoldingInputDispatcher(InputActionType type)
        :base(type)
    {   }

    public override void Update()
    {
        if(IsHolding)
            TriggerInput();
    }

    protected override bool IsValidInputActionType(InputActionType type) => InputActionGroups.HoldingTypes.Contains(type);

    protected override void OnPerformed(InputAction.CallbackContext context)
    {
        base.OnPerformed(context);

        IsHolding = !IsHolding;
    }
}