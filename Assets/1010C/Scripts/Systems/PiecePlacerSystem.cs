using System.Collections.Generic;
using _1010C.Scripts.Components.Tile;
using Entitas;
using UnityEngine;

namespace _1010C.Scripts.Systems
{
    public class PiecePlacerSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public PiecePlacerSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Drag.Removed());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPiece && entity.hasPosition && !entity.flagDrag;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (!SuitableForPlacement(entity, out var tilesToBePlacedOn))
                {
                    Debug.Log("Can't be placed");
                }

                //Destroy the piece here
                foreach (var tile in tilesToBePlacedOn)
                {
                    tile.ReplaceTileState(TileState.Full);
                }
            }
        }

        private bool SuitableForPlacement(GameEntity piece, out List<GameEntity> tilesToBePlacedOn)
        {
            tilesToBePlacedOn = new List<GameEntity>();

            var boardSize = _contexts.game.boardSize.Value;

            //get the tiles to check for full or empty
            var tileList = _contexts.game.GetGroup(GameMatcher.TileState).GetEntities();
            var tiles = new GameEntity[boardSize.x, boardSize.y];
            foreach (var tile in tileList)
            {
                tiles[tile.gridPosition.Value.x, tile.gridPosition.Value.y] = tile;
            }

            //calculate the grid position from float position
            var pos = piece.position.Value;
            var gridX = (int) (pos.x + 0.5f);
            var gridY = (int) (pos.y + 0.5f);

            //check if the piece can be placed
            foreach (var cubePos in piece.pieceCubePositions.Value)
            {
                var cubeX = gridX + cubePos.x;
                var cubeY = gridY + cubePos.y;

                if (cubeX < 0 || cubeX > boardSize.x) return false;
                if (cubeY < 0 || cubeY > boardSize.y) return false;

                if (tiles[cubeX, cubeY].tileState.Value == TileState.Full) return false;

                tilesToBePlacedOn.Add(tiles[cubeX, cubeY]);
            }

            return true;
        }
    }
}