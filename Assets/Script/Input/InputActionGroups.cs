using System.Collections.Generic;

public static class InputActionGroups
{

    public static readonly HashSet<InputActionType> Types = new()
    {
        InputActionType.eLeftMousePressed,
        InputActionType.eRightMousePressed
    };
    public static readonly HashSet<InputActionType> HoldingTypes = new()
    {
        InputActionType.eLeftMouseHolding,
        InputActionType.eRightMouseHolding,

        InputActionType.eKeyboardWHolding,
        InputActionType.eKeyboardAHolding,
        InputActionType.eKeyboardSHolding,
        InputActionType.eKeyboardDHolding
    };

    public static readonly HashSet<InputActionType> MouseTypes = new()
    {
        InputActionType.eLeftMousePressed,
        InputActionType.eRightMousePressed,

        InputActionType.eLeftMouseHolding,
        InputActionType.eRightMouseHolding        
    };
}