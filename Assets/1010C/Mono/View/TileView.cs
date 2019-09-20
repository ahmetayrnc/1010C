using UnityEngine;

namespace _1010C.Mono.View
{
    public class TileView : View, IGridPositionListener
    {
        protected override void AddListeners(GameEntity entity)
        {
            entity.AddGridPositionListener(this);
        }

        protected override void InitializeView(GameEntity entity)
        {
        }

        public void OnGridPosition(GameEntity entity, Vector2Int value)
        {
            transform.position = (Vector2) value;
        }
    }
}