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

        var interaction_moveforward = new Interaction_WorkingInteraction_MoveForward(Owner);
        var interaction_movebackward = new Interaction_WorkingInteraction_MoveBackward(Owner);
        var interaction_rotateleft = new Interaction_WorkingInteraction_RotateLeft(Owner);
        var interaction_rotateright = new Interaction_WorkingInteraction_RotateRight(Owner);

        // create list of interactions 
        List<(InteractionBase, InteractionType)> interactions = new List<(InteractionBase, InteractionType)>()
        {   (interaction_Grabbing, InteractionType.FocusedObject),
            (interaction_moveforward, InteractionType.FocusedObject),
            (interaction_movebackward, InteractionType.FocusedObject),
            (interaction_rotateleft, InteractionType.FocusedObject),
            (interaction_rotateright, InteractionType.FocusedObject) };

        // create list of focused interactions
        List<InteractionBase> focusedInteractions = new()
        {   interaction_Grabbing,
            interaction_EarningMoney,
            interaction_moveforward,
            interaction_movebackward,
            interaction_rotateleft,
            interaction_rotateright, };

        
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