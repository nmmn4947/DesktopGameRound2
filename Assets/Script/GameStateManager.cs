public sealed class GameStateManager
{
    // Singleton reference
    private static GameStateManager Instance_;
    // Current State
    private GameStateBase CurrState = null;

    // Delegate for broadcasting when the state is changed
    public event System.Action<GameStateType> OnGameStateChanged;

    // initialize the instance
    public static GameStateManager Instance()
    {
        if(Instance_ != null)
            return Instance_;

        Instance_ = new GameStateManager();

        return Instance_;
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
        if(CurrState == NextState)
            return;

        if(CurrState != null)
            CurrState.Exit();

        CurrState = NextState;
        CurrState.Enter();
    
        OnGameStateChanged?.Invoke(CurrState.StateType);
    }

    public GameStateType GetCurrGameStateType()
    {
        return CurrState.StateType;
    }
}
