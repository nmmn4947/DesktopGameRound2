using System.Collections.Generic;
using UnityEngine;

public class InputDispatcherManager
{
    public Dictionary<InputActionType, InputDispatcher> Dispatchers = new();
    public Dictionary<InputActionType, InputDispatcher> HoldingDispatchers = new();

    public void EnableAll()
    {
        foreach(InputDispatcher dispatcher in Dispatchers.Values)
            dispatcher.Enable();

        foreach(InputDispatcher holdingDispatcher in HoldingDispatchers.Values)
            holdingDispatcher.Enable();
    }
    
    public void Enable(InputActionType Type)
    {
        Debug.Log("Enter Enable : " + Type);

        if(Dispatchers.TryGetValue(Type, out InputDispatcher inputDispatcher))
            inputDispatcher.Enable();
        else
            if(HoldingDispatchers.TryGetValue(Type, out InputDispatcher holdingDispatcher))
                holdingDispatcher.Enable();
    }

    public void Update()
    {
        foreach(InputDispatcher holdingDispatcher in HoldingDispatchers.Values)
            holdingDispatcher.Update();
    }

    public void DisableAll()
    {
        foreach(InputDispatcher dispatcher in Dispatchers.Values)
            dispatcher.Disable();
            
        foreach(InputDispatcher holdingDispatcher in HoldingDispatchers.Values)
            holdingDispatcher.Disable();
    }

    public void Disable(InputActionType Type)
    {
        if(Dispatchers.TryGetValue(Type, out InputDispatcher inputDispatcher))
            inputDispatcher.Disable();
        else
            if(HoldingDispatchers.TryGetValue(Type, out InputDispatcher holdingDispatcher))
                holdingDispatcher.Disable();
    }

    public InputDispatcher AddDispatcher(InputActionType Type)
    {
        if(InputActionGroups.Types.Contains(Type))
        {
            if(Dispatchers.ContainsKey(Type))
                return Dispatchers[Type];

            var dispatcher = new InputDispatcher(Type);
            Dispatchers.Add(Type, dispatcher);

            Debug.Log("Add Dispatcher : " + Type);

            return dispatcher;            
        }

        if(InputActionGroups.HoldingTypes.Contains(Type))
        {
            if(HoldingDispatchers.ContainsKey(Type))
                return HoldingDispatchers[Type];

            var dispatcher = new HoldingInputDispatcher(Type);
            HoldingDispatchers.Add(Type, dispatcher);

            Debug.Log("Add Holding Dispatcher : " + Type);

            return dispatcher;            
        }

        return null;
    }

    public InputDispatcher GetDispatcher(InputActionType Type)
    {
        if(Dispatchers.TryGetValue(Type, out var dispatcher))
        return dispatcher;

        if(HoldingDispatchers.TryGetValue(Type, out var holdingDispatcher))
            return holdingDispatcher;
        
        return null;
    }
    
    public void RemoveDispatcher(InputActionType Type)
    {
        if(Dispatchers.TryGetValue(Type, out var inputDispatcher))
        {
            inputDispatcher.Disable();

            if(inputDispatcher.Dispose())
                Dispatchers.Remove(Type);

            Debug.Log("Remove Dispatcher : " + Type);

            return;
        }
            
        if(HoldingDispatchers.TryGetValue(Type, out var inputHoldingDispatcher))
        {
            inputHoldingDispatcher.Disable();

            if(inputHoldingDispatcher.Dispose())
                HoldingDispatchers.Remove(Type);   
                
            Debug.Log("Remove Dispatcher : " + Type);          
        }
    }
}
