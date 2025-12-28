using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSet
{
    private InputManager InputManager_;
    private bool bBound = false;

    protected Dictionary<InteractionBase, InputDispatcher> Interactions = new();
    protected Dictionary<InteractionBase, List<HoldingInputDispatcher>> HoldingInteractions = new();

    public InteractionSet(List<InteractionBase> interactions)
    {
        InputManager_ = InputManager.Instance();

        InputDispatcherManager dispatcherManager = InputManager_.InputDispatchers;

        foreach(var interaction in interactions)
        {
            if(interaction is InteractionBase_MultiInput multiInteraction)
            {
                List<HoldingInputDispatcher> holdingInputDispatchers = new();

                foreach(var type in multiInteraction.Types)
                {
                    InputDispatcher dispatcher = dispatcherManager.GetDispatcher(type);

                    if(dispatcher != null && dispatcher is HoldingInputDispatcher holdingDispatcher)
                        holdingInputDispatchers.Add(holdingDispatcher);
                }

                HoldingInteractions.Add(interaction, holdingInputDispatchers);
            }   
            
            if(interaction is InteractionBase_SingleInput singleInteraction)
            {
                var type = singleInteraction.Type;

                InputDispatcher dispatcher = dispatcherManager.GetDispatcher(type);
                    
                if(dispatcher != null)
                {
                    if(dispatcher is HoldingInputDispatcher holdingInputDispatcher)
                        HoldingInteractions.Add(interaction, new List<HoldingInputDispatcher>{holdingInputDispatcher});
                    else
                        Interactions.Add(interaction, dispatcher);
                }
                else  
                    throw new ArgumentException($"Dispatcher for {type} not found.");
            }   
        }
    }

    public void Update()
    {
        foreach(var interaction in HoldingInteractions)
            if(interaction.Key is InteractionBase_MultiInput multiInput)
                multiInput.Update();
    }
    public void Enable()
    {
        if(bBound)
            return;

        foreach(var interaction in Interactions)
            interaction.Value.OnInputOccurred += interaction.Key.OnPerform;   
            
        foreach(var interaction in HoldingInteractions)
        {
            var dispatchers = interaction.Value;

            foreach(InputDispatcher dispatcher in dispatchers)
                dispatcher.OnInputOccurred += interaction.Key.OnPerform;   
        }

        bBound = true;
    }

    public bool IsBound() => bBound;

    public void Disable()
    {
        if(!bBound)
            return;

        foreach(var interaction in Interactions)
            interaction.Value.OnInputOccurred -= interaction.Key.OnPerform;   
            
        foreach(var interaction in HoldingInteractions)
        {
            var dispatchers = interaction.Value;

            foreach(InputDispatcher dispatcher in dispatchers)
                dispatcher.OnInputOccurred -= interaction.Key.OnPerform;   
        }
        
        bBound = false;
    }

    public void Dispose()
    {
        Disable();

        Interactions.Clear();
        
        foreach(var interaction in HoldingInteractions)
        {
            interaction.Key.Dispose(); 
            interaction.Value.Clear();
        }

        HoldingInteractions.Clear();
        
        InputManager_ = null;
    }
}