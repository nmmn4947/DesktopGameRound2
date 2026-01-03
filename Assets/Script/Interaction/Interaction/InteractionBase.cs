public enum InteractionType
{
    Generic,
    FocusedObject
}

public interface InteractionBase
{
    // Instance of function of On Perform
    public void OnEnter();
    public void OnPerform();
    public void OnExit();
    public void Dispose();
}