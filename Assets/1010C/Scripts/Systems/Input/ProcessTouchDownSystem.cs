using System.Collections.Generic;
using _1010C.Scripts.Components.Reserve;
using Entitas;
using UnityEngine;

namespace _1010C.Scripts.Systems.Input
{
    public class ProcessTouchDownSystem : ReactiveSystem<InputEntity>
    {
        private readonly Contexts _contexts;
        private IGroup<GameEntity> _reserveSlots;

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

                if (!(input.Value.x >= reserveSlotPosition.x - 1.5f) ||
                    !(input.Value.x <= reserveSlotPosition.x + 1.5f)) continue;

                if (!(input.Value.y >= reserveSlotPosition.y - 1.5f) ||
                    !(input.Value.y <= reserveSlotPosition.y + 1.5f)) continue;

                if (reserveSlot.reserveSlotState.Value == ReserveSlotState.Empty) continue;
                if (!reserveSlot.hasPieceInReserve) continue;

                Debug.Log($"touched down to piece with id: {reserveSlot.pieceInReserve.Id}");
            }
        }
    }
}