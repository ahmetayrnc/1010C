using System.Collections.Generic;
using _1010C.Scripts.Components.Cube;
using _1010C.Scripts.Services;
using Entitas;
using UnityEngine;

namespace _1010C.Scripts.Systems
{
    public class CubeRemoverSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public CubeRemoverSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.CubeState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasCubeState;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var boardSize = _contexts.game.boardSize.Value;

            //get the tiles to check for full or empty
            var cubeList = _contexts.game.GetGroup(GameMatcher.CubeState).GetEntities();
            var cubes = new GameEntity[boardSize.x, boardSize.y];
            foreach (var cube in cubeList)
            {
                cubes[cube.gridPosition.Value.x, cube.gridPosition.Value.y] = cube;
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
                    if (cubes[x, y].cubeState.Value == CubeState.Empty)
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
                    if (cubes[x, y].cubeState.Value == CubeState.Empty)
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

                    cubes[x, y].ReplaceCubeState(CubeState.Empty);
                    cubes[x, y].isCubeRemoved = true;

                    tilesCleaned++;
                }
            }

            if (tilesCleaned <= 0) return;

            //increment the score
            ScoreService.IncrementScore(tilesCleaned);
        }
    }
}