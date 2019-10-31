using System.Collections.Generic;
using _1010C.Scripts.Components;
using _1010C.Scripts.Components.Cube;
using Entitas;
using UnityEngine;

namespace _1010C.Scripts.Systems
{
    public class GameOverSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public GameOverSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.CubeState));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            //get the cubes to check for full or empty
            var boardSize = _contexts.game.boardSize.Value;
            var cubeList = _contexts.game.GetGroup(GameMatcher.CubeState).GetEntities();
            var cubes = new GameEntity[boardSize.x, boardSize.y];
            foreach (var cube in cubeList)
            {
                cubes[cube.gridPosition.Value.x, cube.gridPosition.Value.y] = cube;
            }

            //get the pieces in the reserve
            var pieces = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Piece).NoneOf(GameMatcher.Destroyed));

            // try to place every piece into every point on the board
            var gameOver = true;
            foreach (var piece in pieces)
            {
                if (!IsPieceCanBePlaced(piece, cubes, boardSize)) continue;

                gameOver = false;
                break;
            }

            if (gameOver)
            {
                _contexts.game.ReplaceGameState(GameState.Over);
            }
        }

        private static bool IsPieceCanBePlaced(GameEntity piece, GameEntity[,] cubes, Vector2Int boardSize)
        {
            //try every point on the board
            for (var x = 0; x < boardSize.x; x++)
            {
                for (var y = 0; y < boardSize.y; y++)
                {
                    if (CanPlacePiece(piece, cubes, boardSize, x, y)) return true;
                }
            }

            return false;
        }

        private static bool CanPlacePiece(GameEntity piece, GameEntity[,] cubes, Vector2Int boardSize, int x, int y)
        {
            //check if the piece can be placed
            var pos = new Vector2(x, y);
            foreach (var cubePos in piece.pieceType.Value.GetPiecePositions())
            {
                //calculate the grid position from float position
                var cubeX = Mathf.RoundToInt(pos.x + cubePos.x);
                var cubeY = Mathf.RoundToInt(pos.y + cubePos.y);

                if (cubeX < 0 || cubeX >= boardSize.x) return false;

                if (cubeY < 0 || cubeY >= boardSize.y) return false;

                if (cubes[cubeX, cubeY].cubeState.Value == CubeState.Full) return false;
            }

            return true;
        }
    }
}