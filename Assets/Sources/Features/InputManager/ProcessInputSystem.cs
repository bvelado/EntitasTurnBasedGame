using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class ProcessInputSystem : IReactiveSystem, ISetPool
{
    public TriggerOnEvent trigger { get { return Matcher.Input.OnEntityAdded(); } }

    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public void Execute(List<Entity> entities)
    {
        Entity currentControlledUnit = _pool.GetEntities(Matcher.AllOf(Matcher.Unit, Matcher.Controlable))[0];

        foreach(var e in entities)
        {
            switch(e.input.intent)
            {
                case InputIntent.FinishTurn:
                    currentControlledUnit.IsEndTurn(true);

                    break;

                case InputIntent.Attack:
                    Debug.Log(currentControlledUnit);

                    break;
            }

            //_pool.DestroyEntity(e);
        }
    }
}
