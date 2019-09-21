using _1010C.Scripts.Mono.ScriptableObjects;
using UnityEngine;

namespace _1010C.Scripts.Mono.View
{
    public class CubeView : View
    {
        public CubeColors cubeColors;
        public SpriteRenderer spriteRenderer;
        protected override void AddListeners(GameEntity entity)
        {
        }

        protected override void InitializeView(GameEntity entity)
        {
            spriteRenderer.sortingLayerName = TileLayer;
        }
    }
}
