using System.Collections.Generic;
using UnityEngine;

public sealed class CharacterStateManager : MonoBehaviour
{
    private CharacterStateBase CurrState = null;

    // Delegate for broadcasting when the state is changed
    public event System.Action OnCharacterStateChanged;
    
    void Awake()
    {
    }

    void Start()
    {
        Debug.Log("Start - Character State Manager");

        GameStateManager GSManager = GameStateManager.Instance();

        GSManager.OnGameStateChanged += ChangeDefaultCharacterState;
        GSManager.OnGameStateFinished += ExitCharacterState;
        ChangeDefaultCharacterState(GSManager.GetCurrGameStateType());        
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrState != null)
            CurrState.Update();
    }

    void OnDestroy()
    {
        if(CurrState != null)
        {
            CurrState.Dispose();
            CurrState = null;
    
            GameStateManager GSManager = GameStateManager.Instance();

            GSManager.OnGameStateChanged -= ChangeDefaultCharacterState;
            GSManager.OnGameStateFinished -= ExitCharacterState;
        }
    }

    public void ExitCharacterState()
    {
        if(CurrState != null)
        {
            CurrState.Exit();
            CurrState.Dispose();

            CurrState = null;
            OnCharacterStateChanged?.Invoke();
        }
    }

    // change the current game state with the next state reference
    private void ChangeCharacterState(CharacterStateBase NextState)
    {
        if(CurrState == NextState)
            return;

        if(CurrState != null)
        {
            CurrState.Exit();
            CurrState.Dispose();
        }

        OnCharacterStateChanged?.Invoke();

        CurrState = NextState;
        CurrState.Enter();
    }

    // change the current character state when a trigger occur
    public void ChangeCharacterState(CharacterStateType NextStateType)
    {
        var NextState = StateParser.Instance().GetCharacterState(NextStateType, this.gameObject);

        ChangeCharacterState(NextState);

        OnCharacterStateChanged?.Invoke();
    }

    // change the current character state when the game state is changed
    public void ChangeDefaultCharacterState(GameStateType NextGameStateType)
    {
        ChangeCharacterState(StateParser.Instance().GetDefaultCharacterStateType(NextGameStateType)); 
    }
}
