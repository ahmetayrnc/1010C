using _1010C.Scripts.Systems;
using _1010C.Scripts.Systems.Initialize;
using _1010C.Scripts.Systems.Input;
using UnityEngine;

namespace _1010C.Scripts.Mono
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
                    //initialize
                    .Add(new InitializeBoardSystem(contexts))
                    .Add(new InitializeTilesSystem(contexts))
                    .Add(new InitializeReserveSlotsSystem(contexts))

                    //input
                    .Add(new ProcessTouchDownSystem(contexts))
                    .Add(new ProcessTouchUpSystem(contexts))
                    .Add(new CleanupInputSystem(contexts))

                    //drag
                    .Add(new DragSystem(contexts))

                    //placer
                    .Add(new PiecePlacerSystem(contexts))

                    //remover
                    .Add(new CubeRemoverSystem(contexts))

                    //
                    .Add(new ReserveFillSystem(contexts))
                    .Add(new AddViewSystem(contexts))
                    .Add(new GameEventSystems(contexts))

                    //
                    .Add(new DestroySystem(contexts))
                ;
        }

        private void InitWorld()
        {
            _systems.ActivateReactiveSystems();
            _systems.Initialize();
        }
    }
}