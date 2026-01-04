using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class CharacterStateBase : StateBase
{
    public CharacterStateType StateType {get; protected set; } = CharacterStateType.eNone;
    protected GameObject Owner = null;
    protected List<CharacterModule> Modules = null;
    public CharacterStateBase(GameObject Object)
    {
        Owner = Object;
        Modules = new ();
    }

    public abstract void Enter();

    public virtual void Update()
    {
        float dt = Time.deltaTime;

        foreach(var module in Modules)
            module.Update(dt);
    }

    public virtual void Exit()
    {   }

    public virtual void Dispose()
    {
        Owner = null;
        
        foreach(var module in Modules)
            module.Dispose();

        Modules.Clear();
        Modules = null;
    }
}
