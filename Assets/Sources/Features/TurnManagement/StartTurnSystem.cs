using System;
using System.Collections.Generic;
using Entitas;

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
            if(!isProcessing)
            {
                // Executer les calculs de début de tour

                // Donne le controle
            }
        }
    }
}
