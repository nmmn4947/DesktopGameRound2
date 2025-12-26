using System.Collections.Generic;

public abstract class InteractionSet
{
    private InputManager InputManager_;

    protected Dictionary<InteractionBase, InputDispatcher> Interactions = new();
    protected Dictionary<InteractionBase, HoldingInputDispatcher> HoldingInteractions = new();

    public InteractionSet()
    {
        InputManager_ = InputManager.Instance();
    }

    public void Enable()
    {
        foreach(var interaction in Interactions)
            interaction.Value.OnInputOccurred += interaction.Key.OnPerform;
            
        foreach(var interaction in HoldingInteractions)
            interaction.Value.OnInputOccurred += interaction.Key.OnPerform;
    }

    public void Disable()
    {
        foreach(var interaction in Interactions)
            interaction.Value.OnInputOccurred -= interaction.Key.OnPerform;
            
        foreach(var interaction in HoldingInteractions)
            interaction.Value.OnInputOccurred -= interaction.Key.OnPerform;
    }
}