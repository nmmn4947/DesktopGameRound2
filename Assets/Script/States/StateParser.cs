using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public sealed class StateParser
{
    // Singleton Reference
    private static StateParser Instance_;

    // Parser Character State class based on Game State Type 
    private readonly Dictionary<GameStateType, CharacterStateType> GameStateDefaultCharacterStates;

    // Parser Character State generator based on Character State Type
    private readonly Dictionary<CharacterStateType, Func<GameObject, CharacterStateBase>> CharacterStateFactories;

    private StateParser()
    {
        GameStateDefaultCharacterStates = new Dictionary<GameStateType, CharacterStateType>
        {
            { GameStateType.eWorking, CharacterStateType.eWorkingIdle },
            { GameStateType.eResting, CharacterStateType.eRestingIdle }
        };
        
        CharacterStateFactories = new Dictionary<CharacterStateType, Func<GameObject, CharacterStateBase>>
        {
            { CharacterStateType.eWorkingIdle, (owner) => new WorkingIdleState(owner) },
            { CharacterStateType.eWorkingInteraction, (owner) => new WorkingInteractionState(owner) },
            { CharacterStateType.eRestingIdle, (owner) => new RestingIdleState(owner) },
            { CharacterStateType.eRestingInteraction, (owner) => new RestingInteractionState(owner) }  
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
    public CharacterStateBase GetCharacterState(CharacterStateType Type, GameObject owner) => CharacterStateFactories[Type](owner);

    // Getter function - When game state is changed, return the initial character state's type
    public CharacterStateType GetDefaultCharacterStateType(GameStateType Type) => GameStateDefaultCharacterStates[Type];
}