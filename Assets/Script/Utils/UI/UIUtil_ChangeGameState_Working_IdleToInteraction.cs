using UnityEngine;

[CreateAssetMenu(fileName = "UI_ChangeGameState_Working_IdleToInteraction", menuName = "Utils/UI/Working_IdleToInteraction")]
public sealed class UI_ChangeGameState_Working_IdleToInteraction : UIUtil_ChangeGameState
{
    public override void ChangeGameState()
    {
        var CurrType = GameStateManager.Instance().GetCurrGameStateType();

        Debug.Log("UI Util Change GameState - Clicked");

        if(CurrType == GameStateType.eWorking_Idle)
            GameStateManager.Instance().ChangeGameState(new GameState_WorkingInteraction());
        else if(CurrType == GameStateType.eWorking_Interaction)
            GameStateManager.Instance().ChangeGameState(new GameState_WorkingIdle());            
    }
}
