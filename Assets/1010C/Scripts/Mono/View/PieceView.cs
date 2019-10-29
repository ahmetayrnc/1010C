using _1010C.Scripts.Mono.ScriptableObjects;
using DG.Tweening;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.Rendering;

namespace _1010C.Scripts.Mono.View
{
    public class PieceView : View, IPositionListener, IDragListener, IDragRemovedListener, IDestroyedListener
    {
        public PieceColors pieceColors;
        public SortingGroup sortingGroup;
        public Transform relativeContainer;
        public SpriteRenderer[] cubes;

        private const float PieceReserveScale = 0.6f;
        private const float PieceBoardScale = 1f;

        private const float CubeBoardScale = 0.8f;
        private const float CubeReserveScale = 0.9f;

        private const float ReturnToReserveDuration = 0.5f;
        private const float LeaveFromReserveDuration = 0.24f;

        protected override void AddListeners(GameEntity entity)
        {
            entity.AddPositionListener(this);
            entity.AddDragListener(this);
            entity.AddDragRemovedListener(this);
            entity.AddDestroyedListener(this);
        }

        protected override void InitializeView(GameEntity entity)
        {
            sortingGroup.sortingLayerName = PieceLayer;
            var color = entity.color.Value;

            var cubePositions = entity.pieceType.Value.GetPiecePositions();
            var index = 0;
            for (var i = 0; i < cubePositions.Length; i++)
            {
                var pos = cubePositions[i];
                var cube = cubes[i];
                var newPos = transform.position;
                newPos.x += pos.x;
                newPos.y += pos.y;

                cube.gameObject.SetActive(true);
                cube.transform.localPosition = newPos;
                cube.color = pieceColors.CubeColorToColor(color);

                index++;
            }

            for (var i = index; i < cubes.Length; i++)
            {
                cubes[i].gameObject.SetActive(false);
            }
        }

        public void OnPosition(GameEntity entity, Vector2 value)
        {
            transform.position = value;
        }

        public void OnDrag(GameEntity entity)
        {
            sortingGroup.sortingLayerName = AirLayer;

            relativeContainer.DOKill();
            relativeContainer.DOScale(PieceBoardScale, LeaveFromReserveDuration);
            relativeContainer.DOLocalMoveY(entity.pieceType.Value.GetDragPivotDifference(), LeaveFromReserveDuration);

            foreach (var cube in cubes)
            {
                cube.transform.DOKill();
                cube.transform.DOScale(CubeBoardScale, LeaveFromReserveDuration);
            }
        }

        public void OnDragRemoved(GameEntity entity)
        {
            relativeContainer.DOKill();
            relativeContainer.DOScale(PieceReserveScale, ReturnToReserveDuration);
            relativeContainer.DOLocalMoveY(0, LeaveFromReserveDuration);

            foreach (var cube in cubes)
            {
                cube.transform.DOKill();
                cube.transform.DOScale(CubeReserveScale, LeaveFromReserveDuration);
            }

            var reserveSlot = Contexts.sharedInstance.game.GetEntityWithId(entity.reserveSlotForPiece.Id);
            transform.DOKill();
            transform.DOMove(reserveSlot.position.Value, ReturnToReserveDuration).OnComplete(() =>
            {
                entity.ReplacePosition(reserveSlot.position.Value);
                sortingGroup.sortingLayerName = PieceLayer;
            });
        }

        public void OnDestroyed(GameEntity entity)
        {
            GameObject go;
            (go = gameObject).Unlink();
            ViewFactory.DestroyPiece(go);
        }
    }
}