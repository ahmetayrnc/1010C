using System.Collections.Generic;
using Entitas;

namespace _1010C.Scripts.Systems.Input
{
    public class ProcessTouchDownSystem : ReactiveSystem<InputEntity>
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _reserveSlots;

        private const float ReserveSlotRadius = 1.5f;

        public ProcessTouchDownSystem(Contexts contexts) : base(contexts.input)
        {
            _contexts = contexts;
            _reserveSlots = contexts.game.GetGroup(GameMatcher.ReserveSlot);
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.TouchDown);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasTouchDown;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            var inputEntity = entities.SingleEntity();
            var input = inputEntity.touchDown;

            foreach (var reserveSlot in _reserveSlots)
            {
                var reserveSlotPosition = reserveSlot.position.Value;

                if (!(input.Value.x >= reserveSlotPosition.x - ReserveSlotRadius) ||
                    !(input.Value.x <= reserveSlotPosition.x + ReserveSlotRadius)) continue;

                if (!(input.Value.y >= reserveSlotPosition.y - ReserveSlotRadius) ||
                    !(input.Value.y <= reserveSlotPosition.y + ReserveSlotRadius)) continue;

                if (!reserveSlot.hasPieceInReserve) continue;

                var pieceId = reserveSlot.pieceInReserve.Id;
                PieceTouchedDown(pieceId);
                break;
            }
        }

        private void PieceTouchedDown(int pieceId)
        {
            _contexts.game.SetPieceInAir(pieceId);

            var piece = _contexts.game.GetEntityWithId(pieceId);
            piece.flagDrag = true;
        }
    }
}