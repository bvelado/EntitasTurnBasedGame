using Entitas;
using UnityEngine;

public class CreateUnitsSystem : IInitializeSystem {
    public void Initialize()
    {
        for(int i = 6; i > 0; i--)
        {
            var e = Pools.pool.CreateEntity()
                .AddUnit("Unit " + i)
                .AddTurnOrder(Random.Range(0, 100));

            Debug.Log("Unit " + e.unit.name + " created.");
        }
    }
}
