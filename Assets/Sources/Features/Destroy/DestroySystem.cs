using System;
using System.Collections.Generic;
using Entitas;

public class DestroySystem : IReactiveSystem, ISetPool
{
    Pool _pool;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Destroy).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            _pool.DestroyEntity(e);
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}
