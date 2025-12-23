using UnityEngine;

public class RestingInteractionState : CharacterStateBase
{
    public RestingInteractionState(GameObject owner)
        :base(owner)
    { StateType = CharacterStateType.eRestingInteraction; }
    
    public override void Enter()
    {   }
    public override void Update()
    {   }
    public override void Exit()
    {   }
}