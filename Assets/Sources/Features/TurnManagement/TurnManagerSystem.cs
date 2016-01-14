using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class TurnManagerSystem : IInitializeSystem, IReactiveSystem, ISetPool
{
    Group _group;

    List<Entity> managedUnits = new List<Entity>();
    int currentUnitIndex = 0;

    public TriggerOnEvent trigger
    {
        get { return Matcher.AnyOf(Matcher.EndTurn, Matcher.StartTurn).OnEntityAdded(); }
    }

    public void SetPool(Pool pool)
    {
        _group = pool.GetGroup(Matcher.AllOf(Matcher.Unit, Matcher.TurnOrder));
    }

    public void Initialize()
    {
        // Trie les unités par vitesse
        for(int i = 0; i < _group.count; i++)
        {
            Entity fastestEntity = _group.GetEntities()[0];
            float higherSpeed = -1000;

            foreach (var e in _group.GetEntities())
            {
                if (!managedUnits.Contains(e) && e.turnOrder.speed > higherSpeed)
                {
                    fastestEntity = e;
                    higherSpeed = e.turnOrder.speed;
                }
            }
            managedUnits.Add(fastestEntity);
            Debug.Log(fastestEntity.unit.name + " // Speed : " + fastestEntity.turnOrder.speed);
        }

        StartTurn();
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in entities)
        {
            if(e.isStartTurn)
            {
                StartTurn();
            } else if (e.isEndTurn)
            {
                EndTurn();
            }
        }
    }

    void EndTurn()
    {
        // Retirer le contrôle à l'Unit
        managedUnits[currentUnitIndex].IsControlable(false);
    }

    void StartTurn()
    {
        currentUnitIndex++;
        // Donner contrôle à l'Unit
        managedUnits[currentUnitIndex].IsControlable(true);
    }
}
