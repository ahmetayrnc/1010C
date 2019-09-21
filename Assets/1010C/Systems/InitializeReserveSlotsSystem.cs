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

            const int reserveSlotY = -4;
            const int reserveSlotCount = 3;

            for (var i = 0; i < reserveSlotCount; i++)
            {
                var entity = _contexts.game.CreateEntity();
                entity.isReserveSlot = true;
                entity.AddPosition(new Vector2(reserveSlotY, i * (boardSize.Value.x / reserveSlotCount)));
            }
        }
    }
}