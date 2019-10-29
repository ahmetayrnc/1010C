using System.Collections.Generic;
using _1010C.Scripts.Components.Tile;
using _1010C.Scripts.Services;
using Entitas;
using UnityEngine;

namespace _1010C.Scripts.Systems
{
    public class TileCleanerSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public TileCleanerSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TileState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasTileState;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var boardSize = _contexts.game.boardSize.Value;

            //get the tiles to check for full or empty
            var tileList = _contexts.game.GetGroup(GameMatcher.TileState).GetEntities();
            var tiles = new GameEntity[boardSize.x, boardSize.y];
            foreach (var tile in tileList)
            {
                tiles[tile.gridPosition.Value.x, tile.gridPosition.Value.y] = tile;
            }

            //figure out which columns to clean
            var tilesToBeCleaned = new bool[boardSize.x, boardSize.y];
            for (var x = 0; x < boardSize.x; x++)
            {
                for (var y = 0; y < boardSize.y; y++)
                {
                    tilesToBeCleaned[x, y] = false;
                }
            }

            for (var x = 0; x < boardSize.x; x++)
            {
                var fullCol = true;
                for (var y = 0; y < boardSize.y; y++)
                {
                    if (tiles[x, y].tileState.Value == TileState.Empty)
                    {
                        fullCol = false;
                    }
                }

                if (!fullCol) continue;

                for (var y = 0; y < boardSize.y; y++)
                {
                    tilesToBeCleaned[x, y] = true;
                }
            }

            //figure out which rows to clean
            for (var y = 0; y < boardSize.y; y++)
            {
                var fullRow = true;
                for (var x = 0; x < boardSize.x; x++)
                {
                    if (tiles[x, y].tileState.Value == TileState.Empty)
                    {
                        fullRow = false;
                    }
                }

                if (!fullRow) continue;

                for (var x = 0; x < boardSize.x; x++)
                {
                    tilesToBeCleaned[x, y] = true;
                }
            }

            var tilesCleaned = 0;
            //clean the tiles
            for (var x = 0; x < boardSize.x; x++)
            {
                for (var y = 0; y < boardSize.y; y++)
                {
                    if (!tilesToBeCleaned[x, y]) continue;

                    tiles[x, y].ReplaceTileState(TileState.Empty);
                    tiles[x, y].RemoveColor();

                    tilesCleaned++;
                }
            }

            if (tilesCleaned <= 0) return;

            //increment the score
            ScoreService.IncrementScore(tilesCleaned);
        }
    }
}