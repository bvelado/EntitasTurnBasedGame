using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class EndTurnSystem : IReactiveSystem
{
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.EndTurn.OnEntityAddedOrRemoved();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in entities)
        {
            // Quand l'unit prend le component EndTurn
            if(e.isEndTurn)
            {
                // Appliquer les actions de fin de tour ici

                // Retire le component
                e.IsEndTurn(false);
                Debug.Log(e + " finit son tour.");
            } else
            {
                e.IsControlable(false);
            }
        }
    }
}
