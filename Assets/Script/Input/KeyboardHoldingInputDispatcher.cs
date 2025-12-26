using UnityEngine.InputSystem;

public class KeyboardHoldingInputDispatcher : KeyboardInputDispatcher
{
    private bool IsHolding = false;

    public KeyboardHoldingInputDispatcher(InputActionType type)
        :base(type)
    {   }

    public override void Update()
    {
        if(IsHolding)
            TriggerKeyboardInput();
    }

    protected override void OnPerformed(InputAction.CallbackContext context)
    {
        base.OnPerformed(context);

        IsHolding = !IsHolding;
    }
}