using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class TurnManagerSystem : IInitializeSystem, IReactiveSystem, ISetPool
{
    Group _group;

    List<Entity> managedUnits = new List<Entity>();
    int currentUnitIndex = 0;

    int totalTurnsNumber = 1;

    public TriggerOnEvent trigger
    {
        get { return Matcher.AnyOf(Matcher.EndTurn, Matcher.StartTurn).OnEntityRemoved(); }
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
        }

        InitFirstTurn();
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in entities)
        {
            // Si l'unit perd le component EndTurn
            // Lorsque les actions de fin de tour sont terminées
            if(!e.isEndTurn && e.isControlable)
            {

                InitNextTurn();
            // Si l'unit prend le component StartTurn
            // Dés l'execution des actions de début de tour
            }
        }
    }

    void InitFirstTurn()
    {
        Debug.Log("Tour " + totalTurnsNumber + " / " + "Unité " + (currentUnitIndex+1));
        // Initialisation
        managedUnits[currentUnitIndex].IsStartTurn(true);
    }

    void InitNextTurn()
    {
        NextUnitIndex();
        managedUnits[currentUnitIndex].IsStartTurn(true);
        Debug.Log("Tour " + totalTurnsNumber + " / " + "Unité " + (currentUnitIndex+1));
    }

    void NextUnitIndex()
    {
        if (currentUnitIndex +1 > managedUnits.Count-1)
        {
            currentUnitIndex = 0;
            totalTurnsNumber++;
        } else
        {
            currentUnitIndex++;
        }
    }
}
