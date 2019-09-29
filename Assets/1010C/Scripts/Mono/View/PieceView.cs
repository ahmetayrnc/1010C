using _1010C.Scripts.Components.Piece;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

namespace _1010C.Scripts.Mono.View
{
    public class PieceView : View, IPositionListener, IReturningToReserveListener, ILeavingFromReserveListener
    {
        public SortingGroup sortingGroup;
        public Transform scaleContainer;
        public Transform relativeContainer;
        public Transform[] cubes;

        private const float ReserveScale = 0.65f;
        private const float BoardScale = 0.95f;
        private const float ReturnToReserveDuration = 0.5f;
        private const float LeaveFromReserveDuration = 0.24f;

        protected override void AddListeners(GameEntity entity)
        {
            entity.AddPositionListener(this);
            entity.AddReturningToReserveListener(this);
            entity.AddLeavingFromReserveListener(this);
        }

        protected override void InitializeView(GameEntity entity)
        {
            sortingGroup.sortingLayerName = PieceLayer;
            var totalX = 0f;
            var totalY = 0f;
            foreach (var cube in cubes)
            {
                var position = cube.transform.localPosition;
                totalX += position.x;
                totalY += position.y;
            }

            var centerX = totalX / cubes.Length;
            var centerY = totalY / cubes.Length;
            Debug.Log($"({centerX}, {centerY})");
        }

        public void OnPosition(GameEntity entity, Vector2 value)
        {
            transform.position = value;
        }

        public void OnReturningToReserve(GameEntity entity)
        {
            var reserveSlot = Contexts.sharedInstance.game.GetEntityWithId(entity.reserveSlotForPiece.Id);

            scaleContainer.DOScale(ReserveScale, ReturnToReserveDuration);
            transform.DOMove(reserveSlot.position.Value, ReturnToReserveDuration)
                .OnComplete(() => OnReturnToReserveEnded(entity));
        }

        private static void OnReturnToReserveEnded(GameEntity entity)
        {
            entity.isReturningToReserve = false;
        }

        public void OnLeavingFromReserve(GameEntity entity)
        {
            scaleContainer.DOScale(BoardScale, LeaveFromReserveDuration)
                .OnComplete(() => OnLeaveFromReserveEnded(entity));
        }

        private static void OnLeaveFromReserveEnded(GameEntity entity)
        {
            entity.isLeavingFromReserve = false;
        }
    }
}