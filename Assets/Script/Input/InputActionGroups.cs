using System.Collections.Generic;

public static class InputActionGroups
{
    public static readonly HashSet<InputActionType> MouseTypes = new()
    {
        InputActionType.eLeftMouseTapped,
        InputActionType.eLeftMousePressed,
        InputActionType.eRightMouseTapped,
        InputActionType.eRightMousePressed
    };

    public static readonly HashSet<InputActionType> KeyboardTypes = new()
    {
        InputActionType.eKeyboardWPressed,
        InputActionType.eKeyboardAPressed,
        InputActionType.eKeyboardSPressed,
        InputActionType.eKeyboardDPressed
    };
}