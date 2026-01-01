using System.Collections.Generic;
using UnityEngine;
public sealed class GameStateManager
{
    // Singleton reference
    private static GameStateManager Instance_;
    // Current State
    private GameStateBase CurrState = null;

    // Delegate for broadcasting when the state is changed
    public event System.Action<GameStateType> OnGameStateChanged;
    public event System.Action OnGameStateFinished;

    // initialize the instance
    public static GameStateManager Instance()
    {
        if(Instance_ != null)
            return Instance_;   

        Instance_ = new GameStateManager();

        return Instance_;
    }

    private GameStateManager()
    {
        ChangeGameState(new GameState_WorkingIdle());
    }
    // update function
    // call this function in Monobehaviour's update function
    public void Update()
    {
        if(CurrState != null)
            CurrState.Update();
    }

    // change the current game state when a trigger occur
    public void ChangeGameState(GameStateBase NextState)
    {
        Debug.Log("Start to change game state");

        if(CurrState == NextState)
        {
            Debug.Log("Curr state is same as Next state");
            return;   
        }

        InputManager inputManager = InputManager.Instance();

        Debug.Log("Processed change game state");
            
        if(CurrState != null)
        {
            // exit current game state 
            CurrState.Exit();
            // exit all of character's current state
            OnGameStateFinished?.Invoke();
            // reset all of input dispatchers
            inputManager.ResetInputDispatcherSet(CurrState.dispatcherType);
        }

        CurrState = NextState;


        if(CurrState != null)
        {
            Debug.Log("Enter Current State : " + CurrState );
            // enter current game state
            CurrState.Enter();
            // set input dispatchers based on current game state
            inputManager.SetInputDispatcherSet(CurrState.dispatcherType);
            // enter all of character's basic state based on game state
            OnGameStateChanged?.Invoke(CurrState.StateType);   
        }
        else
            Debug.Log("CurrentState is Null");
    }

    public GameStateType GetCurrGameStateType() => CurrState.StateType;
}
