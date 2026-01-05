using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CharacterState_WorkingIdle : CharacterStateBase
{
    public CharacterState_WorkingIdle(GameObject owner)
        :base(owner)
    { StateType = CharacterStateType.eWorking_Idle; }

    public override void Enter()
    {
        if(Owner == null)
            return;

        Owner.GetComponent<CharacterInteractionManager>()?.ChangeInteractions(null);  
        Owner.GetComponent<FocusedHandlerManager>()?.ChangeHandler(null);

        Modules.Add(new PassiveIncomeModule(Owner));
    }
}