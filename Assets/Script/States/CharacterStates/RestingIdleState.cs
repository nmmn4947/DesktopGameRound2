using UnityEngine;

public class RestingIdleState : CharacterStateBase
{
    public RestingIdleState(GameObject owner)
        :base(owner)
    { StateType = CharacterStateType.eRestingIdle; }
    
    public override void Enter()
    {   }
    public override void Update()
    {   }
    public override void Exit()
    {   }
}