using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class ProcessInputSystem : IReactiveSystem, ISetPool
{
    Group _group;

    public TriggerOnEvent trigger { get { return Matcher.Input.OnEntityAdded(); } }

    Pool _pool;

    public void SetPool(Pool pool)
    {
        _group = pool.GetGroup(Matcher.AllOf(Matcher.Unit, Matcher.Controlable));
    }

    public void Execute(List<Entity> entities)
    {
        Entity currentControlledUnit = _group.GetSingleEntity();

        foreach (var e in entities)
        {
            switch(e.input.intent)
            {
                case InputIntent.FinishTurn:
                    if(currentControlledUnit != null && !currentControlledUnit.isStartTurn)
                    {
                        currentControlledUnit.IsEndTurn(true);
                    }

                    break;

                case InputIntent.Attack:
                    Debug.Log(currentControlledUnit);

                    break;
            }
        }
    }
}
