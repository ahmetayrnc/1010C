using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Systems _systems;
    private Contexts _contexts;

    void Start()
    {
        _contexts = Contexts.sharedInstance;
        _systems = CreateSystems(_contexts);
        InitWorld();
    }

    private static Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Systems");
    }

    private void InitWorld()
    {
        _systems.ActivateReactiveSystems();
        _systems.Initialize();
    }
}