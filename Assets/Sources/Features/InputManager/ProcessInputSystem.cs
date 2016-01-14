using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class ProcessInputSystem : IReactiveSystem, ISetPool
{
    Pool pool;

    public TriggerOnEvent trigger
    {
        get { return Matcher.Input.OnEntityAdded(); }
    }

    public void SetPool(Pool pool)
    {
        this.pool = pool;
    }

    public void Execute(List<Entity> entities)
    {
        
    }
}
