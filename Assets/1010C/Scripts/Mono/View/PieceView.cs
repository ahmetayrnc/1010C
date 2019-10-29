using System;
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
        public CubeView[] cubes;

        private const float ReserveScale = 0.65f;
        private const float BoardScale = 0.86f;
        private const float ReturnToReserveDuration = 0.5f;
        private const float LeaveFromReserveDuration = 0.24f;
        private const float CubeSeparationAmount = 0.086f;

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

                cube.SetActive(true);
                cube.transform.localPosition = newPos;
                cube.SetColor(pieceColors.PieceColorToColor(color));

                index++;
            }

            for (var i = index; i < cubes.Length; i++)
            {
                cubes[i].SetActive(false);
            }
        }

        public void OnPosition(GameEntity entity, Vector2 value)
        {
            transform.position = value;
        }

        public void OnDrag(GameEntity entity)
        {
            MoveCubes(MovementType.Separate);
            relativeContainer.DOKill();
            relativeContainer.DOScale(BoardScale, LeaveFromReserveDuration);
            relativeContainer.DOLocalMoveY(entity.pieceType.Value.GetDragPivotDifference(), LeaveFromReserveDuration);
            sortingGroup.sortingLayerName = AirLayer;
        }

        public void OnDragRemoved(GameEntity entity)
        {
            MoveCubes(MovementType.Join);
            relativeContainer.DOKill();
            relativeContainer.DOScale(ReserveScale, ReturnToReserveDuration);
            relativeContainer.DOLocalMoveY(0, LeaveFromReserveDuration);

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

        private enum MovementType
        {
            Separate,
            Join
        }

        private void MoveCubes(MovementType type)
        {
            foreach (var cube in cubes)
            {
                var cubeTransform = cube.transform;
                var cubeLocalPosition = cubeTransform.localPosition;

                var newLocalY = CalculateCubePos(cubeLocalPosition.y, type);
                var newLocalX = CalculateCubePos(cubeLocalPosition.x, type);

                cubeTransform.DOKill();
                cubeTransform.DOLocalMoveX(newLocalX, LeaveFromReserveDuration);
                cubeTransform.DOLocalMoveY(newLocalY, LeaveFromReserveDuration);
            }
        }

        private static float CalculateCubePos(float localVal, MovementType type)
        {
            //if at the center, do not move
            if (!(Math.Abs(localVal) >= 0.001f)) return localVal;

            var multiplier = type == MovementType.Separate ? +1 : -1;
            var amount = localVal / 0.5f;
            localVal += amount * CubeSeparationAmount * multiplier;

            return localVal;
        }
    }
}