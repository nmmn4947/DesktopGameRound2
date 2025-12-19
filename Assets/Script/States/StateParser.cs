using System;
using System.Collections.Generic;

public sealed class StateParser
{
    // Singleton Reference
    private static StateParser Instance_;

    // Parser Character State class based on Game State Type 
    private readonly Dictionary<GameStateType, CharacterStateType> GameStateDefaultCharacterStates;

    // Parser Character State generator based on Character State Type
    private readonly Dictionary<CharacterStateType, Func<CharacterStateBase>> CharacterStateFactories;

    private StateParser()
    {
        GameStateDefaultCharacterStates = new Dictionary<GameStateType, CharacterStateType>
        {
            { GameStateType.eWorking, CharacterStateType.eWorkingIdle },
            { GameStateType.eResting, CharacterStateType.eRestingIdle }
        };
        
        CharacterStateFactories = new Dictionary<CharacterStateType, Func<CharacterStateBase>>
        {
            { CharacterStateType.eWorkingIdle, () => new WorkingIdleState() },
            { CharacterStateType.eWorkingInteraction, () => new WorkingInteractionState() },
            { CharacterStateType.eRestingIdle, () => new RestingIdleState() },
            { CharacterStateType.eRestingInteraction, () => new RestingInteractionState() }  
        };
    }

    public static StateParser Instance()
    {
        if(Instance_ != null)
            return Instance_;

        Instance_ = new StateParser();

        return Instance_;
    }

    // Parser - return the derived CharacterState reference based on character state's type
    public CharacterStateBase GetCharacterState(CharacterStateType Type) => CharacterStateFactories[Type]();

    // Getter function - When game state is changed, return the initial character state's type
    public CharacterStateType GetDefaultCharacterStateType(GameStateType Type) => GameStateDefaultCharacterStates[Type];
}