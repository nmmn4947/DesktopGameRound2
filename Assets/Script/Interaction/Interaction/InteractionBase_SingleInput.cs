using UnityEngine;

public abstract class InteractionBase_SingleInput : InteractionBase
{
    public InputActionType Type = InputActionType.eNone;

    protected GameObject Owner = null;

    public InteractionBase_SingleInput(GameObject owner) => Owner = owner;

    public abstract void OnPerform();

    public void Dispose() => Owner = null;
}