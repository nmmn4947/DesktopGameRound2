using UnityEngine;

public abstract class CharacterModule
{
    protected GameObject Owner = null;

    public CharacterModule(GameObject owner)
    {
        Owner = owner;
    }

    public abstract void Update(float dt);

    public virtual void Dispose() => Owner = null;
}