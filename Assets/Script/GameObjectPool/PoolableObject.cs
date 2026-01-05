using System;
using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    public bool InUse { get; private set; } = false;

    public virtual void Initialize()
    {
        
    }
}