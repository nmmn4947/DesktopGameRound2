using System;
using System.Collections.Generic;

public class InteractionSet
{
    // Input binding class is for collections of specific dispatcher and type based on each interactions
    private class InputBinding
    {
        public InputDispatcher Dispatcher = null;
        public InteractionType InteractionType = InteractionType.Generic;
        public bool bBound = false;

        public InputBinding(InputDispatcher dispatcher, InteractionType interactionType)
        {
            Dispatcher = dispatcher;
            InteractionType = interactionType;
        }

        public void Dispose()
        {
            if(bBound)
                throw new ArgumentException("Needed to check unbind interactions");

            Dispatcher = null;
        }
    }
    private InputManager InputManager_ = null;

    private Dictionary<InteractionBase, InputBinding> Interactions = new();
    private Dictionary<InteractionBase, List<InputBinding>> HoldingInteractions = new();

    // ctor of InteractionSets, get the list of interactions and insert into proper dictionaries
    public InteractionSet(List<(InteractionBase, InteractionType)> interactions)
    {        
        InputManager_ = InputManager.Instance();

        // add each interactions into proper interaction dictionaries
        foreach(var interaction in interactions)
            Add(interaction.Item1, interaction.Item2);
    }

    // when the interaction is inserted, this function can create inputbinding based on the interaction's input action type
    private void Add(InteractionBase Interaction, InteractionType interactionType)
    {
        InputDispatcherManager dispatcherManager = InputManager_.InputDispatchers;

        // check whether the interaction is multi input or not 
        if(Interaction is InteractionBase_MultiInput multiInteraction)
        {
            List<InputBinding> holdingInputDispatchers = new();

            // the interaction is multi input so need progresses to add each types' dispatcher
            foreach(var type in multiInteraction.Types)
            {
                InputDispatcher dispatcher = dispatcherManager.GetDispatcher(type);

                // check the dispatcher is valid and the valid dispatcher is holding input dispatcher
                if(dispatcher != null && dispatcher is HoldingInputDispatcher holdingDispatcher)
                    holdingInputDispatchers.Add(new(holdingDispatcher, interactionType));
            }

            HoldingInteractions.Add(Interaction, holdingInputDispatchers);
        }   

        // check whether the interaction is single input or not  
        if(Interaction is InteractionBase_SingleInput singleInteraction)
        {
            var type = singleInteraction.Type;

            InputDispatcher dispatcher = dispatcherManager.GetDispatcher(type);
                    
            // if the matched dispatcher is available
            if(dispatcher != null)
            {
                // check whether the dispatcher is holding dispatcher or not 
                if(dispatcher is HoldingInputDispatcher holdingInputDispatcher)
                    // add the holding interaction dictionary
                    HoldingInteractions.Add(Interaction, new List<InputBinding>{new (holdingInputDispatcher, interactionType)});
                else
                    // add the interaction dictionary
                    Interactions.Add(Interaction, new(dispatcher, interactionType));
            }
            else  
                throw new ArgumentException($"Dispatcher for {type} not found.");
        }
    }

    public void Update()
    {
        // update each multi input interaction's valid perform check 
        foreach(var interaction in HoldingInteractions)
            if(interaction.Key is InteractionBase_MultiInput multiInput)
                multiInput.Update();
    }
    
    public void Enable(InteractionBase interaction)
    {
        if(Interactions.ContainsKey(interaction))
        {
            InputBinding inputBinding = Interactions[interaction];
        
            if(!inputBinding.bBound)
            {
                inputBinding.Dispatcher.Bind(interaction.OnEnter , interaction.OnPerform, interaction.OnExit);
                inputBinding.bBound = true;                
            }
        }
        
        if(HoldingInteractions.ContainsKey(interaction))
        {
            List<InputBinding> inputBindings = HoldingInteractions[interaction];
        
            foreach(var binding in inputBindings)
                if(!binding.bBound)
                {            
                    binding.Dispatcher.Bind(interaction.OnEnter , interaction.OnPerform, interaction.OnExit);
                    binding.bBound = true;
                }
        }
    }

    // bind the interaction of generic type with the proper dispatchers
    public void GenericEnableAll()
    {
        // bind interactions' OnPerform function with proper dispatcher
        foreach(var interaction in Interactions)
        {
            // check whether it is not bound yet, and check whter it is generic type or not
            if(!interaction.Value.bBound && interaction.Value.InteractionType == InteractionType.Generic)
            {
                interaction.Value.Dispatcher.Bind(interaction.Key.OnEnter, interaction.Key.OnPerform, interaction.Key.OnExit);
                interaction.Value.bBound = true;                
            }
        }

        // bind interactions' OnPerform function with proper dispatchers
        foreach(var interaction in HoldingInteractions)
        {
            var inputBindings = interaction.Value;

            foreach(var inputBinding in inputBindings)
                // check whether it is not bound yet, and check whter it is generic type or not
                if(!inputBinding.bBound && inputBinding.InteractionType == InteractionType.Generic)
                {
                    inputBinding.Dispatcher.Bind(interaction.Key.OnEnter, interaction.Key.OnPerform, interaction.Key.OnExit); 
                    inputBinding.bBound = true;      
                }
        }
    }

    public void Disable(InteractionBase interaction)
    {
        if(Interactions.ContainsKey(interaction))
        {
            InputBinding inputBinding = Interactions[interaction];
        
            if(inputBinding.bBound)
            {
                inputBinding.Dispatcher.Unbind(interaction.OnEnter, interaction.OnPerform, interaction.OnExit);
                inputBinding.bBound = false;   
            }
        }
        
        if(HoldingInteractions.ContainsKey(interaction))
        {
            List<InputBinding> inputBindings = HoldingInteractions[interaction];
        
            foreach(var binding in inputBindings)
            {
                if(binding.bBound)
                {                
                    binding.Dispatcher.Unbind(interaction.OnEnter, interaction.OnPerform, interaction.OnExit);
                    binding.bBound = false;   
                }
            }
        }
    }

    public void DisableAll()
    {
        // unbind interactions' onperform function to each dispatcher
        foreach(var interaction in Interactions)
        {
            var binding = interaction.Value;

            if(binding.bBound)
            {

                binding.Dispatcher.Unbind(interaction.Key.OnEnter, interaction.Key.OnPerform, interaction.Key.OnExit);
                binding.bBound = false;       
            }
        }
            
        // unbind interactions' onperform function to each dispatchers
        foreach(var interaction in HoldingInteractions)
        {
            var bindings = interaction.Value;

            foreach(var binding in bindings)
            {
                if(binding.bBound)
                {
                    binding.Dispatcher.Unbind(interaction.Key.OnEnter, interaction.Key.OnPerform, interaction.Key.OnExit);
                    binding.bBound = false;
                }
            } 
        }
    }

    public void Dispose()
    {
        // explicitly unbind
        DisableAll();

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