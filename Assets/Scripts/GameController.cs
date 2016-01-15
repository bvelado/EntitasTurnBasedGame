using Entitas;
using Entitas.Unity.VisualDebugging;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Systems _systems;

    void Start()
    {
        Random.seed = 42;

        _systems = createSystems(Pools.pool);
        _systems.Initialize();
    }

    void Update()
    {
        _systems.Execute();
    }

    Systems createSystems(Pool pool)
    {
#if (UNITY_EDITOR)
        return new DebugSystems()
#else
        return new Systems()
#endif
        // Unit generation
        .Add(pool.CreateSystem<CreateUnitsSystem>())

        // Start and end turn
        .Add(pool.CreateSystem<StartTurnSystem>())
        .Add(pool.CreateSystem<EndTurnSystem>())

        // Turn manager
        .Add(pool.CreateSystem<TurnManagerSystem>())

        // Render
        .Add(pool.CreateSystem<AddViewSystem>())
        .Add(pool.CreateSystem<RemoveViewSystem>())

        // Input
        .Add(pool.CreateSystem<ProcessInputSystem>())

        // Destroy
        .Add(pool.CreateSystem<DestroySystem>());
        
    }
}