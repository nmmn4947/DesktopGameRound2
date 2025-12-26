using System.Collections.Generic;

public abstract class InteractionBase
{
    public List<InputActionType> InputType = new();

    public abstract void OnPerform();
}