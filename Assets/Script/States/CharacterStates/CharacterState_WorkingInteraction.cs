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

        // create focused interaction stuff
        var interaction_Grabbing = new Interaction_WorkingInteraction_Grabbing(Owner);
        var interaction_EarningMoney = new Interaction_WorkingInteraction_EarningMoney(Owner);

        // create list of interactions 
        List<(InteractionBase, InteractionType)> interactions = new List<(InteractionBase, InteractionType)>()
        {   (interaction_Grabbing, InteractionType.FocusedObject),
            (interaction_EarningMoney, InteractionType.FocusedObject) };

        // create list of focused interactions
        List<InteractionBase> focusedInteractions = new()
        {   interaction_Grabbing,
            interaction_EarningMoney };

        
        var manager = Owner.GetComponent<CharacterInteractionManager>();

        if(manager != null)
        {
            // change interations and set focused interactions
            manager.ChangeInteractions(new InteractionSet(interactions));  
            manager.GenericEnableAll();   
            manager.SetFocusedInteractions(focusedInteractions);
        }

        Owner.GetComponent<FocusedHandlerManager>()?.ChangeHandler(new CharacterFocusedHandler(Owner));
        Modules.Add(new PassiveIncomeModule());
    }
    public override void Exit()
    {
        Owner.GetComponent<FocusedHandlerManager>()?.ChangeHandler(null);
        Owner.GetComponent<CharacterInteractionManager>()?.DisableAll();
    }
}