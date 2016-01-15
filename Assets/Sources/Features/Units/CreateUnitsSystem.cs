using Entitas;
using UnityEngine;

public class CreateUnitsSystem : IInitializeSystem, ISetPool {

    Pool _pool;

    public void Initialize()
    {
        for(int i = 6; i > 0; i--)
        {
            var e = _pool.CreateEntity()
                .AddUnit("Unit " + i)
                .AddTurnOrder(Random.Range(0, 100));
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}
