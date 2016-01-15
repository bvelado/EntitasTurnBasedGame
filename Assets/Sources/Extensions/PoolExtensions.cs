using UnityEngine;
using Entitas;

public static class PoolExtension {

    static readonly string[] _units =
    {
        ViewRes.UnitWarrior,
        ViewRes.UnitThief
    };

    static readonly string[] _unitsNames = RandomNameRes.randomNames;

    public static Entity CreateRandomUnit(this Pool pool)
    {
        return pool.CreateEntity()
            .AddUnit(_unitsNames[Random.Range(0, _unitsNames.Length)])
            .AddTurnOrder(Random.Range(0, 100))
            .AddResource(_units[Random.Range(0, _units.Length)]);
    }
}
