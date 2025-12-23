public sealed class InputManager
{
    private static InputManager Instance_;

    public InputHandleSetCommon InputHandleCommon;
    public InputHandleSet CurrentHandle = null;

    public static InputManager Instance()
    {
        if(Instance_ != null)
            return Instance_;

        Instance_ = new InputManager();

        return Instance_;
    }

    public InputManager()
    {
        InputHandleCommon = new();
        InputHandleCommon.Enable();
    }

    public void ChangeInputHandleSet(InputHandleSet NextInputHandleSet)
    {
        if(CurrentHandle != null)
            CurrentHandle.Disable();

        CurrentHandle = NextInputHandleSet;
        CurrentHandle.Enable();
    }
}