using Entitas;
using UnityEngine;

public class CreateUnitsSystem : IInitializeSystem, ISetPool {

    Pool _pool;

    public void Initialize()
    {
        for(int i = 6; i > 0; i--)
        {
            PoolExtension.CreateRandomUnit(_pool);
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}
