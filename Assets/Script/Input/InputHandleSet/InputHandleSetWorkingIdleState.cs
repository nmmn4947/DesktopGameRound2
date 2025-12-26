public sealed class InputHandleSetWorkingIdleState : InputHandleSet
{
    public InputHandleSetWorkingIdleState()
    {
        AddHoldingDispatcher(InputActionType.eKeyboardWHolding);

    }
}
