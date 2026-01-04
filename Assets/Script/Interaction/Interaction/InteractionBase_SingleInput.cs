using UnityEngine;

public abstract class InteractionBase_SingleInput : InteractionBase
{
    public InputActionType Type = InputActionType.eNone;

    protected GameObject Owner = null;

    public InteractionBase_SingleInput(GameObject owner) => Owner = owner;

    public virtual void OnEnter(){}
    public abstract void OnPerform();
    public virtual void OnExit(){}
    public virtual void Dispose() => Owner = null;
}