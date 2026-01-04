using UnityEngine;

public class CharacterFocusedHandler : FocusedHandler
{
    public CharacterFocusedHandler(GameObject owner)
    :base(owner) {    }

    public override void Focused() =>
        Owner?.GetComponent<CharacterInteractionManager>()
            ?.EnableFocusedInteractions();

    public override void UnFocused() =>
        Owner?.GetComponent<CharacterInteractionManager>()
            ?.DisableFocusedInteractions();
}