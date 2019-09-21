using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _1010C.Scripts.Components.Reserve
{
    public enum ReserveSlotState
    {
        Empty,
        Full
    }

    [Game, Event(EventTarget.Self)]
    public class ReserveSlotStateComponent : IComponent
    {
        public ReserveSlotState Value;
    }
}