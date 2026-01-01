using UnityEngine;

public class CharacterFocusedHandler : FocusedHandler
{
    public CharacterFocusedHandler(GameObject owner)
    :base(owner) {    }

    public override void Focused() =>
        Owner?.GetComponent<CharacterStateManager>()
            ?.ChangeCharacterState(CharacterStateType.eWorking_Focused);

    public override void UnFocused() =>
        Owner?.GetComponent<CharacterStateManager>()
            ?.ChangeCharacterState(CharacterStateType.eWorking_Interaction);
}