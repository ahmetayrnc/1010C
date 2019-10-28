using _1010C.Scripts.Components.Tile;
using _1010C.Scripts.Mono.ScriptableObjects;
using UnityEngine;

namespace _1010C.Scripts.Mono.View
{
    public class TileView : View, IGridPositionListener, ITileStateListener
    {
        public PieceColors pieceColors;
        public SpriteRenderer spriteRenderer;

        protected override void AddListeners(GameEntity entity)
        {
            entity.AddGridPositionListener(this);
            entity.AddTileStateListener(this);
        }

        protected override void InitializeView(GameEntity entity)
        {
            spriteRenderer.sortingLayerName = TileLayer;
        }

        public void OnGridPosition(GameEntity entity, Vector2Int value)
        {
            transform.position = (Vector2) value;
        }

        public void OnTileState(GameEntity entity, TileState value)
        {
            if (value == TileState.Full)
            {
                spriteRenderer.color = pieceColors.PieceColorToColor(entity.color.Value);
            }
        }
    }
}