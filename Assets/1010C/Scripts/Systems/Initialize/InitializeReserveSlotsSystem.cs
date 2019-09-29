using _1010C.Scripts.Components.Reserve;
using _1010C.Scripts.Services;
using Entitas;
using UnityEngine;

namespace _1010C.Scripts.Systems
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
            var boardSize = _contexts.game.boardSize;

            const int reserveSlotY = -2;
            var positions = new[]
            {
                new Vector2(1.5f, reserveSlotY),
                new Vector2(5f, reserveSlotY),
                new Vector2(8.5f, reserveSlotY),
            };

            _contexts.game.SetReserveSlotPositions(positions);

            foreach (var pos in positions)
            {
                CreateReserveSlot(pos);
            }
        }

        private void CreateReserveSlot(Vector2 pos)
        {
            var entity = _contexts.game.CreateEntity();
            entity.isReserveSlot = true;
            entity.AddPosition(pos);
            entity.AddReserveSlotState(ReserveSlotState.Empty);
            entity.AddId(IdService.GetNewId());
        }
    }
}