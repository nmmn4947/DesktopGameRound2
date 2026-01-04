using UnityEngine;

[CreateAssetMenu(fileName = "UI_ChangeGameState_WorkingToResting", menuName = "Utils/UI/WorkingToResting")]
public sealed class UI_ChangeGameState_WorkingToResting : UIUtil_ChangeGameState
{
    public override void ChangeGameState()
    {
        var CurrType = GameStateManager.Instance().GetCurrGameStateType();

        Debug.Log("UI Util Change GameState - Clicked");

        if(GameStateGroups.GameState_WorkingTypes.Contains(CurrType))
            GameStateManager.Instance().ChangeGameState(new RestingState());
            else if(GameStateGroups.GameState_RestingTypes.Contains(CurrType))
            GameStateManager.Instance().ChangeGameState(new GameState_WorkingIdle());
    }
}