using System.Collections.Generic;
using UnityEngine;

public sealed class CharacterStateManager : MonoBehaviour
{
    private CharacterStateBase CurrState = null;

    private Dictionary<CharacterStateType, CharacterStateBase> CachedStates;
    
    void Awake()
    {
        CachedStates = new Dictionary<CharacterStateType, CharacterStateBase>
        {
            {CharacterStateType.eWorkingIdle, new WorkingIdleState() },
            {CharacterStateType.eRestingIdle, new RestingIdleState() }
        };

        GameStateManager GSManager = GameStateManager.Instance();

        GSManager.OnGameStateChanged += ChangeDefaultCharacterState;
        ChangeDefaultCharacterState(GSManager.GetCurrGameStateType());
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrState.Update();
    }

    // change the current game state with the next state reference
    private void ChangeCharacterState(CharacterStateBase NextState)
    {
        if(CurrState == NextState)
            return;

        if(CurrState != null)
            CurrState.Exit();

        CurrState = NextState;
        CurrState.Enter();
    }

    // change the current character state when a trigger occur
    public void ChangeCharacterState(CharacterStateType NextStateType)
    {
        CharacterStateBase NextState = null;

        if(!CachedStates.TryGetValue(NextStateType, out NextState))
            NextState = StateParser.Instance().GetCharacterState(NextStateType);

        ChangeCharacterState(NextState);
    }

    // change the current character state when the game state is changed
    public void ChangeDefaultCharacterState(GameStateType NextGameStateType)
    {
        ChangeCharacterState(StateParser.Instance().GetDefaultCharacterStateType(NextGameStateType)); 
    }
}
