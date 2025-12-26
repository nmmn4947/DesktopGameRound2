using UnityEngine.InputSystem;

public class MouseHoldingInputDispatcher : MouseInputDispatcher
{
    private bool IsHolding = false;

    public MouseHoldingInputDispatcher(InputActionType type)
        :base(type)
    {   }

    public override void Update()
    {
        if(IsHolding)
            TriggerMouseInput();
    }

    protected override void OnPerformed(InputAction.CallbackContext context)
    {
        base.OnPerformed(context);

        IsHolding = !IsHolding;
    }
}