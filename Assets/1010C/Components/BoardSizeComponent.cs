using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace _1010C.Components
{
    [Game, Unique]
    public class BoardSizeComponent : IComponent
    {
        public Vector2Int Value;
    }
}
