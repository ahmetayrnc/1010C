using System.Collections.Generic;
using _1010C.Scripts.Components.Piece;
using _1010C.Scripts.Components.Reserve;
using _1010C.Scripts.Services;
using Entitas;
using UnityEngine;

namespace _1010C.Scripts.Systems
{
    public class ReserveFillSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public ReserveFillSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.PieceInReserve.Removed());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isReserveSlot;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var reserveSlots = _contexts.game.GetGroup(GameMatcher.ReserveSlot).GetEntities();
            TryFillReserve(reserveSlots);
        }

        private static void TryFillReserve(GameEntity[] entities)
        {
            var hasReservePiece = false;
            foreach (var reserveSlot in entities)
            {
                if (reserveSlot.hasPieceInReserve)
                {
                    hasReservePiece = true;
                }
            }

            if (hasReservePiece) return;

            //fill the reserve
            foreach (var reserveSlot in entities)
            {
                PieceCreationService.CreateReservePiece(reserveSlot);
            }
        }
    }
}