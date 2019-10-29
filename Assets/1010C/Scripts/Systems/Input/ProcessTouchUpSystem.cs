using System.Collections.Generic;
using Entitas;

namespace _1010C.Scripts.Systems.Input
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
            if (!_contexts.game.hasPieceInAir) return;

            var piece = _contexts.game.GetEntityWithId(_contexts.game.pieceInAir.Id);
            _contexts.game.RemovePieceInAir();

            if (piece == null) return;

            piece.flagDrag = false;
        }
    }
}