using _1010C.Scripts.Components.Cube;
using _1010C.Scripts.Components.Piece;
using _1010C.Scripts.Misc;
using _1010C.Scripts.Mono.ScriptableObjects;
using DG.Tweening;
using UnityEngine;

namespace _1010C.Scripts.Mono.View
{
    public class CubeView : View, IGridPositionListener, IColorListener, ICubeRemovedListener, ICubePlacedListener
    {
        public PieceColors colors;
        public Transform relativeContainer;
        public SpriteRenderer spriteRenderer;

        private const float CubeDisappearDuration = 0.2f;
        private const float CubeBoardScale = 0.9f;

        protected override void AddListeners(GameEntity entity)
        {
            entity.AddGridPositionListener(this);
            entity.AddColorListener(this);
            entity.AddCubeRemovedListener(this);
            entity.AddCubePlacedListener(this);
        }

        protected override void InitializeView(GameEntity entity)
        {
            spriteRenderer.sortingLayerName = CubeLayer;
            var cubeFull = entity.cubeState.Value == CubeState.Full;
            spriteRenderer.enabled = cubeFull;
            if (cubeFull)
            {
                relativeContainer.localScale = Vector3.one * CubeBoardScale;
            }
        }

        public void OnGridPosition(GameEntity entity, Vector2Int value)
        {
            transform.position = (Vector2) value;
        }

        public void OnColor(GameEntity entity, CubeColor value)
        {
            spriteRenderer.color = colors.CubeColorToColor(value);
        }

        public void OnCubeRemoved(GameEntity entity)
        {
            //calculate extra delay
            var cubePos = transform.position;
            var touchPos = Contexts.sharedInstance.input.GetGroup(InputMatcher.TouchPosition).GetSingleEntity()
                .touchPosition.Value;
            touchPos.y += 2f;
            var boardSize = Contexts.sharedInstance.game.boardSize.Value;

            var maxDistance = Vector2.Distance(boardSize, touchPos);
            var cubeDistance = Vector2.Distance(cubePos, touchPos);
            var delay = cubeDistance.Map(0, maxDistance, 0f, 0.7f);

            //play the animation
            relativeContainer.DOKill();
            relativeContainer.DOScale(0, CubeDisappearDuration + delay)
                .OnComplete(() => { spriteRenderer.enabled = false; });
            entity.isCubeRemoved = false;
        }

        public void OnCubePlaced(GameEntity entity)
        {
            spriteRenderer.enabled = true;
            relativeContainer.localScale = Vector3.one * CubeBoardScale;
            entity.isCubePlaced = false;
        }
    }
}