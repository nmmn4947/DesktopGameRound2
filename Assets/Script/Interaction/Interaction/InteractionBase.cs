public enum InteractionType
{
    Generic,
    FocusedObject
}

public interface InteractionBase
{
    // Instance of function of On Perform
    public void OnPerform();

    public void Dispose();
}