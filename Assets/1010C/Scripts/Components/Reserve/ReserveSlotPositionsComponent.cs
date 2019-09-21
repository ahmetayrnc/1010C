using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace _1010C.Scripts.Components.Reserve
{
    [Game, Unique]
    public class ReserveSlotPositionsComponent : IComponent
    {
        public Vector2[] Value;
    }
}
