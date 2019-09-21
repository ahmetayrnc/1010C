using System.Collections.Generic;
using _1010C.Components.Reserve;
using Entitas;
using UnityEngine;

namespace _1010C.Systems
{
    public class ReserveFillSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public ReserveFillSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        public ReserveFillSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.ReserveSlotState));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isReserveSlot && entity.hasReserveSlotState;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var hasReservePiece = false;
            foreach (var reserveSlot in entities)
            {
                if (reserveSlot.reserveSlotState.Value == ReserveSlotState.Full)
                {
                    hasReservePiece = true;
                }
            }

            if (hasReservePiece) return;

            //fill the reserve
            foreach (var reserveSlot in entities)
            {
                reserveSlot.ReplaceReserveSlotState(ReserveSlotState.Full);
                CreateReservePiece(reserveSlot.position.Value);
            }
        }

        private void CreateReservePiece(Vector2 pos)
        {
            var piece = _contexts.game.CreateEntity();
            piece.isPiece = true;
            piece.AddPosition(pos);
        }
    }
}