using System.Collections.Generic;
using _1010C.Scripts.Components.Piece;
using Entitas;
using UnityEngine;

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
            if (piece != null)
            {
                CleanupPiece(piece);
            }

            _contexts.game.RemovePieceInAir();
        }

        private static void CleanupPiece(GameEntity piece)
        {
            piece.ReplacePieceState(PieceState.InReserve);
            piece.isDrag = false;
        }
    }
}