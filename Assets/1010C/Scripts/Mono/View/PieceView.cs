using _1010C.Scripts.Components.Piece;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

namespace _1010C.Scripts.Mono.View
{
    public class PieceView : View, IPositionListener, IReturnToReserveStartedListener
    {
        public SortingGroup sortingGroup;

        protected override void AddListeners(GameEntity entity)
        {
            entity.AddPositionListener(this);
            entity.AddReturnToReserveStartedListener(this);
        }

        protected override void InitializeView(GameEntity entity)
        {
            sortingGroup.sortingLayerName = PieceLayer;
        }

        public void OnPosition(GameEntity entity, Vector2 value)
        {
            transform.position = value;
        }

        public void OnReturnToReserveStarted(GameEntity entity)
        {
            var reserveSlot = Contexts.sharedInstance.game.GetEntityWithId(entity.reserveSlotForPiece.Id);
            transform.DOMove(reserveSlot.position.Value, 1f).OnComplete(() => OnReturnToReserveEnded(entity));
            Debug.Log("The Piece should return to its reserve slot here");
            Debug.Log("The Piece should shrink to its reserve size here");
        }

        private static void OnReturnToReserveEnded(GameEntity entity)
        {
            entity.isReturnToReserveStarted = false;
        }
    }
}