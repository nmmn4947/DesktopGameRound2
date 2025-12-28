public abstract class InteractionBase_SingleInput : InteractionBase
{
    public InputActionType Type = InputActionType.eNone;

    public abstract void OnPerform();

    public void Dispose(){}
}