using System;
using System.Collections.Generic;
using Entitas;

public class EndTurnSystem : IReactiveSystem, ISetPool
{
    Pool _pool;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.EndTurn.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        // Process end of turn actions

        foreach(var e in entities)
        {
            e.IsEndTurn(false);
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }


}
