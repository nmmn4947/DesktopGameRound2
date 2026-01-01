using System.Collections.Generic;
using UnityEngine;

public class CharacterState_WorkingFocused : CharacterStateBase
{
    public CharacterState_WorkingFocused(GameObject owner)
        :base(owner)
    { StateType = CharacterStateType.eWorking_Focused; }
    
    public override void Enter()
    {
        if(Owner == null)
            return;

        Owner.GetComponent<CharacterInteractionManager>()?.ChangeInteractions(null);  
    }
    public override void Update()
    {
        if(Owner == null)
            return;

        Owner.transform.position = MouseUtil.MouseFollowUtil.GetMouseFollowPosition(Owner.transform.position);
    }
    public override void Exit()
    {   }
}