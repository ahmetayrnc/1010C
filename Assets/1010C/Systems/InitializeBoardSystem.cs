using Entitas;
using UnityEngine;

namespace _1010C.Systems
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
        }
    }
}