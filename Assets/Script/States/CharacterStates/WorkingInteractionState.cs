using UnityEngine;

public class WorkingInteractionState : CharacterStateBase
{
    public WorkingInteractionState(GameObject owner)
        :base(owner)
    { StateType = CharacterStateType.eWorkingInteraction; }
    
    public override void Enter()
    {   }
    public override void Update()
    {   }
    public override void Exit()
    {   }
}