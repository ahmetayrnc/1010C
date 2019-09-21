using _1010C.Systems;
using _1010C.Systems.Input;
using UnityEngine;

namespace _1010C.Mono
{
    public class GameController : MonoBehaviour
    {
        private Entitas.Systems _systems;
        private Contexts _contexts;

        private void Start()
        {
            _contexts = Contexts.sharedInstance;
            _systems = CreateSystems(_contexts);
            InitWorld();
        }

        private void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        private static Entitas.Systems CreateSystems(Contexts contexts)
        {
            return new Feature("Systems")
                    .Add(new InitializeBoardSystem(contexts))
                    .Add(new InitializeTilesSystem(contexts))
                    .Add(new InitializeReserveSlotsSystem(contexts))
                    .Add(new InputSystem(contexts))
                    .Add(new ReserveFillSystem(contexts))
                    .Add(new AddViewSystem(contexts))
                    .Add(new GameEventSystems(contexts))
                ;
        }

        private void InitWorld()
        {
            _systems.ActivateReactiveSystems();
            _systems.Initialize();
        }
    }
}