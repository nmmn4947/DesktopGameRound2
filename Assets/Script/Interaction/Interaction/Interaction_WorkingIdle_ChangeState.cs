using UnityEngine;

public sealed class Interaction_WorkingIdle_ChangeState : InteractionBase_SingleInput
{
    public Interaction_WorkingIdle_ChangeState(GameObject owner)
        :base(owner)
    {
        Type = InputActionType.eKeyboardWPressed;
    }

    public override void OnPerform()
    {
        Debug.Log("Called On Perform - Interaction Working Idle - Change State");
        GameStateManager.Instance().ChangeGameState(new GameState_WorkingInteraction());
    }
}