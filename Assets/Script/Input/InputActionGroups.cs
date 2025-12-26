using System.Collections.Generic;

public static class InputActionGroups
{
    public static readonly HashSet<InputActionType> MouseTypes = new()
    {
        InputActionType.eLeftMousePressed,
        InputActionType.eRightMousePressed
    };

    public static readonly HashSet<InputActionType> MouseHoldingTypes = new()
    {
        InputActionType.eLeftMouseHolding,
        InputActionType.eRightMouseHolding
    };

    public static readonly HashSet<InputActionType> KeyboardTypes = new()
    {   };

    public static readonly HashSet<InputActionType> KeyboardHoldingTypes = new()
    {
        InputActionType.eKeyboardWHolding,
        InputActionType.eKeyboardAHolding,
        InputActionType.eKeyboardSHolding,
        InputActionType.eKeyboardDHolding
    };
}