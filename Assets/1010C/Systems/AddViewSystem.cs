using System.Collections.Generic;
using _1010C.Mono.View;
using Entitas;

namespace _1010C.Systems
{
    public class AddViewSystem : ReactiveSystem<GameEntity>
    {
        public AddViewSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.GridPosition));
        }

        protected override bool Filter(GameEntity entity)
        {
            return !entity.hasView && entity.hasGridPosition;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                InstantiateView(e);
            }
        }

        private static void InstantiateView(GameEntity entity)
        {
            var gameObject = entity.isTile ? ViewFactory.SpawnTile() : ViewFactory.SpawnCube();
            var view = gameObject.GetComponent<View>();
            view.Link(entity);
            entity.AddView(view);
        }
    }
}