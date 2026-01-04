using UnityEngine;

public sealed class Interaction_WorkingInteraction_MoveBackward : InteractionBase_SingleInput
{
    public Interaction_WorkingInteraction_MoveBackward(GameObject owner)
        :base(owner)
    {
        Type = InputActionType.eKeyboardSHold;
    }

    public override void OnPerform()
    {
        if(Owner == null)
            return;

        Camera cam = MouseUtil.MouseFollowUtil.Camera;

        if(cam != null)
            Owner.transform.position -= cam.transform.forward
                * CharacterMovementUtil.CharacterMovementSpeed * Time.deltaTime;
    }
}