using UnityEngine;

public sealed class Interaction_WorkingInteraction_Grabbing : InteractionBase_SingleInput
{
    public Interaction_WorkingInteraction_Grabbing(GameObject owner)
        :base(owner)
    {
        Type = InputActionType.eLeftMouseHold;
    }

    private Vector3 Offset;

    public override void OnEnter()
    {
        if(Owner == null)
            return;

        Offset = Owner.transform.position - MouseUtil.MouseFollowUtil.GetMouseFollowPosition(Owner.transform.position);
    }

    public override void OnPerform()
    {
        if(Owner == null)
            return;

        Owner.transform.position = MouseUtil.MouseFollowUtil.GetMouseFollowPosition(Owner.transform.position) + Offset;
    }
}