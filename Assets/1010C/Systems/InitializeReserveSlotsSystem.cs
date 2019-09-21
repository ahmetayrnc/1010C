using _1010C.Components.Reserve;
using Entitas;
using UnityEngine;

namespace _1010C.Systems
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

            const int reserveSlotCount = 3;
            const int reserveSlotY = -3;
            float[] xPositions = { 1.5f,  5f, 8.5f};

            for (var i = 0; i < reserveSlotCount; i++)
            {
                CreateReserveSlot(new Vector2(xPositions[i], reserveSlotY));
            }
        }

        private void CreateReserveSlot(Vector2 pos)
        {
            var entity = _contexts.game.CreateEntity();
            entity.isReserveSlot = true;
            entity.AddPosition(pos);
            entity.AddReserveSlotState(ReserveSlotState.Empty);
        }
    }
}