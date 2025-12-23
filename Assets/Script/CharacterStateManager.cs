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
            {CharacterStateType.eWorkingIdle, new WorkingIdleState(this.gameObject) },
            {CharacterStateType.eRestingIdle, new RestingIdleState(this.gameObject) }
        };

        GameStateManager GSManager = GameStateManager.Instance();

        GSManager.ChangeGameState(new WorkingState());

        GSManager.OnGameStateChanged += ChangeDefaultCharacterState;
        ChangeDefaultCharacterState(GSManager.GetCurrGameStateType());
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
            NextState = StateParser.Instance().GetCharacterState(NextStateType, this.gameObject);

        ChangeCharacterState(NextState);
    }

    // change the current character state when the game state is changed
    public void ChangeDefaultCharacterState(GameStateType NextGameStateType)
    {
        ChangeCharacterState(StateParser.Instance().GetDefaultCharacterStateType(NextGameStateType)); 
    }
}
