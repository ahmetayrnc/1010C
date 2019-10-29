using _1010C.Scripts.Services;
using Entitas;
using UnityEngine;

namespace _1010C.Scripts.Systems.Initialize
{
    public class InitializeReserveSlotsSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;

        public InitializeReserveSlotsSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            //Move these to a component pls
            const int reserveSlotY = -3;
            var positions = new[]
            {
                new Vector2(1f, reserveSlotY),
                new Vector2(4.5f, reserveSlotY),
                new Vector2(8f, reserveSlotY),
            };

            _contexts.game.SetReserveSlotPositions(positions);

            foreach (var pos in positions)
            {
                CreateReserveSlot(pos);
            }
        }

        private void CreateReserveSlot(Vector2 pos)
        {
            var reserveSlot = _contexts.game.CreateEntity();
            reserveSlot.isReserveSlot = true;
            reserveSlot.AddPosition(pos);
            reserveSlot.AddId(IdService.GetNewId());

            PieceCreationService.CreateReservePiece(reserveSlot);
        }
    }
}