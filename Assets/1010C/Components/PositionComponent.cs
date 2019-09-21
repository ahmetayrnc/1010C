using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace _1010C.Components
{
    [Game, Event(EventTarget.Self)]
    public class PositionComponent : IComponent
    {
        public Vector2 Value;
    }
}
