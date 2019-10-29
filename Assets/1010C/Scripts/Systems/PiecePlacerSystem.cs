using System.Collections.Generic;
using _1010C.Scripts.Components.Tile;
using _1010C.Scripts.Services;
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
            foreach (var piece in entities)
            {
                //check if we can place the piece
                if (!SuitableForPlacement(piece, out var tilesToBePlacedOn)) continue;

                PlacePiece(piece, tilesToBePlacedOn);
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

            //check if the piece can be placed
            var pos = piece.position.Value + Vector2.up * piece.pieceType.Value.GetDragPivotDifference();
            foreach (var cubePos in piece.pieceType.Value.GetPiecePositions())
            {
                //calculate the grid position from float position
                var cubeX = Mathf.RoundToInt(pos.x + cubePos.x);
                var cubeY = Mathf.RoundToInt(pos.y + cubePos.y);

                if (cubeX < 0 || cubeX >= boardSize.x) return false;
                if (cubeY < 0 || cubeY >= boardSize.y) return false;

                if (tiles[cubeX, cubeY].tileState.Value == TileState.Full) return false;

                tilesToBePlacedOn.Add(tiles[cubeX, cubeY]);
            }

            return true;
        }

        private void PlacePiece(GameEntity piece, List<GameEntity> tilesToBePlacedOn)
        {
            //Empty the reserveSlot
            var reserveSlot = _contexts.game.GetEntityWithId(piece.reserveSlotForPiece.Id);
            reserveSlot.RemovePieceInReserve();

            var tilesFilled = 0;
            //Make the tiles occupied
            foreach (var tile in tilesToBePlacedOn)
            {
                tile.ReplaceTileState(TileState.Full);
                tile.AddColor(piece.color.Value);
                tilesFilled++;
            }

            //Destroy the piece
            piece.isDestroyed = true;

            //increment the score
            ScoreService.IncrementScore(tilesFilled);
        }
    }
}