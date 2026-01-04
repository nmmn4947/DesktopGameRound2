using UnityEngine;

public sealed class Interaction_WorkingInteraction_RotateRight : InteractionBase_SingleInput
{
    public Interaction_WorkingInteraction_RotateRight(GameObject owner)
        :base(owner)
    {
        Type = InputActionType.eKeyboardDHold;
    }

    public override void OnPerform()
    {
        if(Owner == null)
            return;

        Owner.transform.Rotate(Vector3.up, 
            -CharacterMovementUtil.CharacterRotateSpeed * Time.deltaTime);
    }
}