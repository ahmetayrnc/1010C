using System;
using _1010C.Scripts.Misc;
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
        public Transform scaleContainer;
        public CubeView[] cubes;

        private const float ReserveScale = 0.65f;
        private const float BoardScale = 0.9f;
        private const float ReturnToReserveDuration = 0.5f;
        private const float LeaveFromReserveDuration = 0.24f;
        private const float CubeSeparationAmount = 0.1f;

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
            var color = pieceColors.colors.PickRandom();
            foreach (var cube in cubes)
            {
                cube.SetColor(color);
            }
        }

        public void OnPosition(GameEntity entity, Vector2 value)
        {
            transform.position = value;
        }

        public void OnDrag(GameEntity entity)
        {
            MoveCubes(MovementType.Separate);
            scaleContainer.DOScale(BoardScale, LeaveFromReserveDuration);
        }

        public void OnDragRemoved(GameEntity entity)
        {
            var reserveSlot = Contexts.sharedInstance.game.GetEntityWithId(entity.reserveSlotForPiece.Id);

            scaleContainer.DOScale(ReserveScale, ReturnToReserveDuration);
            transform.DOMove(reserveSlot.position.Value, ReturnToReserveDuration);
            MoveCubes(MovementType.Join);
        }

        public void OnDestroyed(GameEntity entity)
        {
            GameObject go;
            (go = gameObject).Unlink();
            Destroy(go);
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
                var cubePosition = cubeTransform.position;
                var centerPosition = transform.position;

                var difY = cubePosition.y - centerPosition.y;
                var difX = cubePosition.x - centerPosition.x;

                var newLocalY = CalculateNewValueFromDif(difY, cubeLocalPosition.y, type);
                var newLocalX = CalculateNewValueFromDif(difX, cubeLocalPosition.x, type);

                cubeTransform.DOLocalMoveX(newLocalX, LeaveFromReserveDuration);
                cubeTransform.DOLocalMoveY(newLocalY, LeaveFromReserveDuration);
            }
        }

        private static float CalculateNewValueFromDif(float dif, float oldValue, MovementType type)
        {
            if (!(Math.Abs(dif) >= 0.001f)) return oldValue;

            if (dif > 0) dif = 1;
            if (dif < 0) dif = -1;

            var multiplier = type == MovementType.Separate ? +1 : -1;
            oldValue += dif * CubeSeparationAmount * multiplier;

            return oldValue;
        }
    }
}