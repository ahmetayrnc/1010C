using System.Collections.Generic;
using Entitas;

namespace _1010C.Scripts.Systems
{
    public class DestroySystem : ReactiveSystem<GameEntity>
    {
        public DestroySystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Destroyed.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDestroyed;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Destroy();
            }
        }
    }
}