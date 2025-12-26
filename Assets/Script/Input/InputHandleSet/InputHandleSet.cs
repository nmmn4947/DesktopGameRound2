using System.Collections.Generic;

public abstract class InputHandleSet
{
    public Dictionary<InputActionType, InputDispatcher> Dispatchers = new();
    public Dictionary<InputActionType, InputDispatcher> HoldingDispatchers = new();

    public void Enable()
    {
        foreach(InputDispatcher dispatcher in Dispatchers.Values)
            dispatcher.Enable();

        foreach(InputDispatcher dispatchers in HoldingDispatchers.Values)
            dispatchers.Enable();
    }

    public void Update()
    {
        foreach(InputDispatcher dispatcher in HoldingDispatchers.Values)
            dispatcher.Update();
    }

    public void Disable()
    {
        foreach(InputDispatcher dispatcher in Dispatchers.Values)
            dispatcher.Disable();
            
        foreach(InputDispatcher dispatcher in HoldingDispatchers.Values)
            dispatcher.Disable();
    }

    protected void AddDispatcher(InputActionType Type)
    {
        if(InputActionGroups.KeyboardTypes.Contains(Type))
            Dispatchers.Add(Type, new KeyboardInputDispatcher(Type));

        if(InputActionGroups.MouseTypes.Contains(Type))
            Dispatchers.Add(Type, new MouseInputDispatcher(Type));
    }

    protected void AddHoldingDispatcher(InputActionType Type)
    {
        if(InputActionGroups.KeyboardHoldingTypes.Contains(Type))
            HoldingDispatchers.Add(Type, new KeyboardHoldingInputDispatcher(Type));

        if(InputActionGroups.MouseHoldingTypes.Contains(Type))
            HoldingDispatchers.Add(Type, new MouseInputDispatcher(Type));
    }
}
