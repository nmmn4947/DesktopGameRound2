using System.Collections.Generic;

public abstract class InputHandleSet
{
    public Dictionary<InputActionType, InputDispatcher> Dispatchers = new();
    public void Enable()
    {
        foreach(InputDispatcher dispatcher in Dispatchers.Values)
            dispatcher.Enable();
    }

    public void Disable()
    {
        foreach(InputDispatcher dispatcher in Dispatchers.Values)
            dispatcher.Disable();
    }

    protected void AddDispatcher(InputActionType Type)
    {
        if(InputActionGroups.KeyboardTypes.Contains(Type))
            Dispatchers.Add(Type, new KeyboardInputDispatcher(Type));

        if(InputActionGroups.MouseTypes.Contains(Type))
            Dispatchers.Add(Type, new MouseInputDispatcher(Type));
    }
}
