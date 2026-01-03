using System.Collections.Generic;
using UnityEngine;

public class CharacterState_WorkingInteraciton : CharacterStateBase
{
    public CharacterState_WorkingInteraciton(GameObject owner)
        :base(owner)
    { StateType = CharacterStateType.eWorking_Interaction; }
    
    public override void Enter()
    {
        List<(InteractionBase, InteractionType)> interactions = new List<(InteractionBase, InteractionType)>()
        {   (new Interaction_WorkingInteraction_Grabbing(Owner), InteractionType.Generic),
            (new Interaction_WorkingInteraction_EarningMoney(Owner), InteractionType.Generic) };

        if(Owner == null)
            return;

        var manager = Owner.GetComponent<CharacterInteractionManager>();

        if(manager != null)
        {
            manager.ChangeInteractions(new InteractionSet(interactions));  
            manager.GenericEnableAll();   
        }
    }
    public override void Update()
    {   }
    public override void Exit() => Owner.GetComponent<CharacterInteractionManager>()?.DisableAll();
}