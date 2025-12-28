using System.Collections.Generic;
using UnityEngine;

public class CharacterState_WorkingIdle : CharacterStateBase
{
    public CharacterState_WorkingIdle(GameObject owner)
        :base(owner)
    { StateType = CharacterStateType.eWorkingIdle; }

    public override void Enter()
    {
        List<InteractionBase> interactions = new List<InteractionBase>{
            new Interaction_WorkingIdle_ChangeState()
        };

        if(Owner != null)
        {
            CharacterInteractionManager manager = Owner.GetComponent<CharacterInteractionManager>();

            if(manager != null)
            {
                manager.ChangeInteractions(new InteractionSet(interactions));  
                manager.Enable();                
            }
        }
    }
    
    public override void Update()
    {   }
    public override void Exit()
    {   }
}