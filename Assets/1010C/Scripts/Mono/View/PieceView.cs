using _1010C.Scripts.Components.Piece;
using UnityEngine;
using UnityEngine.Rendering;

namespace _1010C.Scripts.Mono.View
{
    public class PieceView : View, IPositionListener, IPieceStateListener
    {
        public SortingGroup sortingGroup;

        protected override void AddListeners(GameEntity entity)
        {
            entity.AddPositionListener(this);
            entity.AddPieceStateListener(this);
        }

        protected override void InitializeView(GameEntity entity)
        {
            sortingGroup.sortingLayerName = PieceLayer;
        }

        public void OnPosition(GameEntity entity, Vector2 value)
        {
            transform.position = value;
        }

        public void OnPieceState(GameEntity entity, PieceState value)
        {
            Debug.Log($"piece with id: {entity.id.Value} is in {value}");
        }
    }
}