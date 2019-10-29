using _1010C.Scripts.Components.Cube;
using UnityEngine;

namespace _1010C.Scripts.Mono.View
{
    public class CubeView : View, ICubeStateListener, IGridPositionListener
    {
        public SpriteRenderer spriteRenderer;

        protected override void AddListeners(GameEntity entity)
        {
            entity.AddCubeStateListener(this);
            entity.AddGridPositionListener(this);
        }

        protected override void InitializeView(GameEntity entity)
        {
            spriteRenderer.sortingLayerName = CubeLayer;
        }

        public void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public void OnCubeState(GameEntity entity, CubeState value)
        {
            if (value == CubeState.Full)
            {
                spriteRenderer.enabled = true;
                spriteRenderer.color = Color.black;
            }

            if (value == CubeState.Empty)
            {
                spriteRenderer.enabled = false;
            }
        }

        public void OnGridPosition(GameEntity entity, Vector2Int value)
        {
            transform.position = (Vector2) value;
        }
    }
}