using System.Collections.Generic;

public static class GameStateGroups
{
    public static readonly HashSet<GameStateType> GameState_WorkingTypes = new()
    {
        GameStateType.eWorking_Idle,
        GameStateType.eWorking_Interaction,
    };
    public static readonly HashSet<GameStateType> GameState_RestingTypes = new()
    {
        GameStateType.eResting,
    };
}