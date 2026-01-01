using System.Collections.Generic;
using UnityEngine;

public class CharacterState_WorkingFocused : CharacterStateBase
{
    private Vector3 Offset;

    public CharacterState_WorkingFocused(GameObject owner)
        :base(owner)
    { StateType = CharacterStateType.eWorking_Focused; }
    
    public override void Enter()
    {
        if(Owner == null)
            return;

        Owner.GetComponent<CharacterInteractionManager>()?.ChangeInteractions(null);  
        
        Offset = Owner.transform.position - MouseUtil.MouseFollowUtil.GetMouseFollowPosition(Owner.transform.position);
    }
    public override void Update()
    {
        if(Owner == null)
            return;

        Owner.transform.position = MouseUtil.MouseFollowUtil.GetMouseFollowPosition(Owner.transform.position) + Offset;
    }
    public override void Exit()
    {   }

    public override void Dispose()
    {
        base.Dispose();
    }
}