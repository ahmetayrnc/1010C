using _1010C.Scripts.Components.Cube;
using _1010C.Scripts.Components.Piece;
using _1010C.Scripts.Mono.ScriptableObjects;
using UnityEngine;

namespace _1010C.Scripts.Mono.View
{
    public class CubeView : View, ICubeStateListener, IGridPositionListener, IColorListener
    {
        public PieceColors colors;
        public SpriteRenderer spriteRenderer;

        protected override void AddListeners(GameEntity entity)
        {
            entity.AddCubeStateListener(this);
            entity.AddGridPositionListener(this);
            entity.AddColorListener(this);
        }

        protected override void InitializeView(GameEntity entity)
        {
            spriteRenderer.sortingLayerName = CubeLayer;
        }

        public void OnCubeState(GameEntity entity, CubeState value)
        {
            spriteRenderer.enabled = value == CubeState.Full;
        }

        public void OnGridPosition(GameEntity entity, Vector2Int value)
        {
            transform.position = (Vector2) value;
        }

        public void OnColor(GameEntity entity, CubeColor value)
        {
            spriteRenderer.color = colors.CubeColorToColor(value);
        }
    }
}