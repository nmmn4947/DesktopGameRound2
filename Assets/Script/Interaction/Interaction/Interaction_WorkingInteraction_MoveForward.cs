using UnityEngine;

public sealed class Interaction_WorkingInteraction_MoveForward : InteractionBase_SingleInput
{
    public Interaction_WorkingInteraction_MoveForward(GameObject owner)
        :base(owner)
    {
        Type = InputActionType.eKeyboardWHold;
    }

    public override void OnPerform()
    {
        if(Owner == null)
            return;

        Camera cam = MouseUtil.MouseFollowUtil.Camera;

        if(cam != null)
            Owner.transform.position += cam.transform.forward
                * CharacterMovementUtil.CharacterMovementSpeed * Time.deltaTime;
    }
}