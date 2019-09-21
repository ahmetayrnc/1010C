using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _1010C.Systems.Input
{
    public class ProcessTouchUpSystem : ReactiveSystem<InputEntity>
    {
        private readonly Contexts _contexts;

        public ProcessTouchUpSystem(Contexts contexts) : base(contexts.input)
        {
            _contexts = contexts;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.TouchUp);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasTouchUp;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            var inputEntity = entities.SingleEntity();
            var input = inputEntity.touchUp;

            Debug.Log($"touched up: {input.Value}");
        }
    }
}