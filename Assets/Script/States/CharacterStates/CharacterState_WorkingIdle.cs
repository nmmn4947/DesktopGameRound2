using System.Collections.Generic;
using UnityEngine;

public class CharacterState_WorkingIdle : CharacterStateBase
{
    public CharacterState_WorkingIdle(GameObject owner)
        :base(owner)
    { StateType = CharacterStateType.eWorking_Idle; }

    public override void Enter()
    {
        List<(InteractionBase, InteractionType)> interactions = new List<(InteractionBase, InteractionType)>()
        {(new Interaction_WorkingIdle_ChangeState(Owner), InteractionType.Generic) };

        if(Owner == null)
            return;

        CharacterInteractionManager manager = Owner.GetComponent<CharacterInteractionManager>();

        if(manager != null)
        {
            manager.ChangeInteractions(new InteractionSet(interactions));  
            manager.GenericEnableAll();
        }

        Owner.GetComponent<FocusedHandlerManager>()?.ChangeHandler(null);
    }
    
    public override void Update()
    {   }
    
    public override void Exit()
    {
        Owner.GetComponent<CharacterInteractionManager>()?.DisableAll();  
    }
}