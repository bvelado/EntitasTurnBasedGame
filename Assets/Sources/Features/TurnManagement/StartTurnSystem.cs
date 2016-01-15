using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class StartTurnSystem : IReactiveSystem
{
    bool isProcessing = false;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.StartTurn.OnEntityAddedOrRemoved();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            // Quand l'unit prend le component StartTurn
            if(e.isStartTurn)
            {
                Debug.Log(e + " débute son tour.");
                // Execute les actions de début de tour

                // Retire le component StartTurn
                e.IsStartTurn(false);
            } else
            {
                e.IsControlable(true);
            }
        }
    }
}
