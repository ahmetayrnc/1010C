using UnityEngine;
using UnityEngine.Rendering;

namespace _1010C.Scripts.Mono.View
{
    public class PieceView : View, IPositionListener
    {
        public SortingGroup sortingGroup;

        protected override void AddListeners(GameEntity entity)
        {
            entity.AddPositionListener(this);
        }

        protected override void InitializeView(GameEntity entity)
        {
            sortingGroup.sortingLayerName = PieceLayer;
        }

        public void OnPosition(GameEntity entity, Vector2 value)
        {
            transform.position = value;
        }
    }
}