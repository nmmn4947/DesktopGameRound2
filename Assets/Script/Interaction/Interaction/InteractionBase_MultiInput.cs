using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionBase_MultiInput : InteractionBase
{
    protected bool bPerformed = false;
    protected bool bValidPerform = false;

    protected GameObject Owner = null;

    public List<InputActionType> Types;
    private List<HoldingInputDispatcher> Dispatchers = new();

    public InteractionBase_MultiInput(GameObject owner, List<InputActionType> types)
    {
        InputDispatcherManager dispatcherManager = InputManager.Instance().InputDispatchers;

        foreach(var type in types)
        {
            if(!InputActionGroups.HoldingTypes.Contains(type))
                throw new ArgumentException("Invalid type in InputActionType, need to change Holding Input Action Type");
            
            InputDispatcher dispatcher = dispatcherManager.GetDispatcher(type);

            if(dispatcher != null && dispatcher is HoldingInputDispatcher holdingDispatcher)
                Dispatchers.Add(holdingDispatcher);
        }

        Types = types;

        Owner = owner;
    }

    public virtual void OnEnter(){}
    public abstract void OnPerform();
    public virtual void OnExit(){}
    private bool IsValidPerform()
    {
        foreach(HoldingInputDispatcher dispatcher in Dispatchers)
            if(!dispatcher.IsHolding())
                return false;

        return true;
    }

    public void Update()
    {
        bPerformed = false;
        bValidPerform = IsValidPerform();
    }

    public void Dispose()
    {
        Owner = null;
        Dispatchers.Clear();
        Types.Clear();
    }
}