using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace _1010C.Scripts.Components.Input
{
    [Input, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class TouchDownComponent : IComponent
    {
        public Vector2 Value;
    }
    
    [Input, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class TouchUpComponent : IComponent
    {
        public Vector2 Value;
    }
}