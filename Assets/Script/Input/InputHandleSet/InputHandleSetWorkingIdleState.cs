public sealed class InputHandleSetWorkingIdleState : InputHandleSet
{
    public InputHandleSetWorkingIdleState()
    {
        AddDispatcher(InputActionType.eKeyboardWPressed);
    }
}
