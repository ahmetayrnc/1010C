using System.Collections.Generic;
using Entitas;
using UnityEngine;

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
            e.AddView(InstantiateView(e));
        }
    }

    IView InstantiateView(GameEntity entity)
    {
        var gameObject = new GameObject();
        var view = gameObject.AddComponent<View>();
        view.Link(entity);
        return view;
    }
}