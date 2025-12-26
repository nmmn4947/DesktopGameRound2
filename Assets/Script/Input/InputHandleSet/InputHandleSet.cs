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
        if(InputActionGroups.Types.Contains(Type))
            Dispatchers.Add(Type, new InputDispatcher(Type));
    }

    protected void AddHoldingDispatcher(InputActionType Type)
    {
        if(InputActionGroups.HoldingTypes.Contains(Type))
            HoldingDispatchers.Add(Type, new HoldingInputDispatcher(Type));
    }
}
