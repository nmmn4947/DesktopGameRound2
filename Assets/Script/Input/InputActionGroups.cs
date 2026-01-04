using System.Collections.Generic;

public static class InputActionGroups
{

    public static readonly HashSet<InputActionType> Types = new()
    {
        InputActionType.eLeftMousePressed,
        InputActionType.eLeftMouseTapped,
    };
    public static readonly HashSet<InputActionType> HoldingTypes = new()
    {
        InputActionType.eLeftMouseHold,
    };
}