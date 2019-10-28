using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace _1010C.Scripts.Components.Board
{
    [Game, Unique]
    public class ReserveSlotPositionsComponent : IComponent
    {
        public Vector2[] Value;
    }
}
