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
            { GameStateType.eWorking_Idle, CharacterStateType.eWorking_Idle },
            { GameStateType.eWorking_Interaction, CharacterStateType.eWorking_Interaction },
            { GameStateType.eResting, CharacterStateType.eRestingIdle }
        };
        
        CharacterStateFactories = new Dictionary<CharacterStateType, Func<GameObject, CharacterStateBase>>
        {
            { CharacterStateType.eWorking_Idle, (owner) => new CharacterState_WorkingIdle(owner) },
            { CharacterStateType.eWorking_Interaction, (owner) => new CharacterState_WorkingInteraciton(owner) },
            { CharacterStateType.eWorking_Focused, (owner) => new CharacterState_WorkingFocused(owner) },
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