using UnityEngine;

public sealed class Interaction_WorkingInteraction_RotateLeft : InteractionBase_SingleInput
{
    public Interaction_WorkingInteraction_RotateLeft(GameObject owner)
        :base(owner)
    {
        Type = InputActionType.eKeyboardAHold;
    }

    public override void OnPerform()
    {
        if(Owner == null)
            return;

        Owner.transform.Rotate(Vector3.up, 
            CharacterMovementUtil.CharacterRotateSpeed * Time.deltaTime);
    }
}