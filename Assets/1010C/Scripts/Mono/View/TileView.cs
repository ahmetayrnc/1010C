using UnityEngine;

namespace _1010C.Scripts.Mono.View
{
    public class TileView : View, IGridPositionListener
    {
        public SpriteRenderer spriteRenderer;
        
        protected override void AddListeners(GameEntity entity)
        {
            entity.AddGridPositionListener(this);
        }

        protected override void InitializeView(GameEntity entity)
        {
            spriteRenderer.sortingLayerName = TileLayer;
        }

        public void OnGridPosition(GameEntity entity, Vector2Int value)
        {
            transform.position = (Vector2) value;
        }
    }
}