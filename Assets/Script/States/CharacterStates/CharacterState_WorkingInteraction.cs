using System.Collections.Generic;
using UnityEngine;

public class CharacterState_WorkingInteraciton : CharacterStateBase
{
    public CharacterState_WorkingInteraciton(GameObject owner)
        :base(owner)
    { StateType = CharacterStateType.eWorking_Interaction; }
    
    public override void Enter()
    {
        if(Owner == null)
            return;

        CharacterInteractionManager manager = Owner.GetComponent<CharacterInteractionManager>();

        if(manager != null)
            manager.ChangeInteractions(null);  

        Owner.GetComponent<FocusedHandlerManager>()?.ChangeHandler(new CharacterFocusedHandler(Owner));
    }
    public override void Update()
    {   }
    public override void Exit()
    {   }
}