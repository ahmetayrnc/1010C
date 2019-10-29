using Entitas;
using UnityEngine;

namespace _1010C.Scripts.Components.Input
{
    [Input]
    public sealed class TouchDownComponent : IComponent
    {
        public Vector2 Value;
    }
    
    [Input]
    public sealed class TouchUpComponent : IComponent
    {
        public Vector2 Value;
    }
    
    [Input]
    public sealed class TouchPositionComponent : IComponent
    {
        public Vector2 Value;
    }
}