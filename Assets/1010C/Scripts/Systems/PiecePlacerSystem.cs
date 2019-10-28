using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _1010C.Scripts.Systems
{
    public class PiecePlacerSystem : ReactiveSystem<GameEntity>
    {
        public PiecePlacerSystem(Contexts contexts) : base(contexts.game)
        {
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
                var place = SuitableForPlacement(entity);
            }
        }

        private bool SuitableForPlacement(GameEntity piece)
        {
            var pos = piece.position.Value;
            var gridX = (int) (pos.x + 0.5f);
            var gridY = (int) (pos.y + 0.5f);
            return true;
        }
    }
}