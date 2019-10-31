using _1010C.Scripts.Components;
using Entitas;
using UnityEngine;

namespace _1010C.Scripts.Systems.Initialize
{
    public class InitializeBoardSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;

        public InitializeBoardSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            _contexts.game.SetBoardSize(new Vector2Int(10, 10));
            _contexts.game.SetIdCount(0);
            _contexts.game.SetScore(0);
            _contexts.game.SetGameState(GameState.Playing);
        }
    }
}