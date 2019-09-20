using System.Collections.Generic;
using Entitas;

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
        return entity.hasGridPosition;
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
        var gameObject = ViewFactory.SpawnCube();
        var view = gameObject.GetComponent<CubeView>();
        view.Link(entity);
        entity.AddView(view);
    }
}