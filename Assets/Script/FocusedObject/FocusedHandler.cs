using UnityEngine;

public abstract class FocusedHandler
{
    protected GameObject Owner = null;

    public FocusedHandler(GameObject owner) => Owner = owner;
    public abstract void Focused();

    public abstract void UnFocused();

    public virtual void Dispose() => Owner = null;
}