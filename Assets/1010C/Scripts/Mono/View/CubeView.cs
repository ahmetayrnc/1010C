using _1010C.Scripts.Mono.ScriptableObjects;
using UnityEngine;

namespace _1010C.Scripts.Mono.View
{
    public class CubeView : View
    {
        public SpriteRenderer spriteRenderer;

        protected override void AddListeners(GameEntity entity)
        {
        }

        protected override void InitializeView(GameEntity entity)
        {
            spriteRenderer.sortingLayerName = TileLayer;
        }

        public void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }
    }
}