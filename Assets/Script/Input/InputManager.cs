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

    private InputManager()
    {
        InputHandleCommon = new();
        InputHandleCommon.Enable();
    }

    public void Update()
    {
        InputHandleCommon.Update();

        if(CurrentHandle != null)
            CurrentHandle.Update();
    }

    public void ChangeInputHandleSet(InputHandleSet NextInputHandleSet)
    {
        if(CurrentHandle != null)
            CurrentHandle.Disable();

        CurrentHandle = NextInputHandleSet;

        if(CurrentHandle != null)
            CurrentHandle.Enable();
    }
}