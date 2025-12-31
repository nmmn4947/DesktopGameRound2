using System.Collections.Generic;
using UnityEngine;

public class CharacterState_WorkingInteraciton : CharacterStateBase
{
    public CharacterState_WorkingInteraciton(GameObject owner)
        :base(owner)
    { StateType = CharacterStateType.eWorkingInteraction; }
    
    public override void Enter()
    {
        if(Owner != null)
        {
            CharacterInteractionManager manager = Owner.GetComponent<CharacterInteractionManager>();

            if(manager != null)
                manager.ChangeInteractions(null);  
        }
    }
    public override void Update()
    {   }
    public override void Exit()
    {   }
}