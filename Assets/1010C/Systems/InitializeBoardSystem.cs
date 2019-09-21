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
            //Todo read this from somewhere else
            _contexts.game.SetBoardSize(new Vector2Int(10, 10));

            var boardSize = _contexts.game.boardSize;

            for (var x = 0; x < boardSize.Value.x; x++)
            {
                for (var y = 0; y < boardSize.Value.y; y++)
                {
                    CreateTile(x, y);
                }
            }
        }

        private void CreateTile(int x, int y)
        {
            var tileEntity = _contexts.game.CreateEntity();
            
            tileEntity.isTile = true;
            tileEntity.AddGridPosition(new Vector2Int(x, y));
        }
    }
}