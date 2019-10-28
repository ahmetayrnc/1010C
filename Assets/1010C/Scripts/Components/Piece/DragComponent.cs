using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _1010C.Scripts.Components.Piece
{
    [Game, FlagPrefix("flag"), Event(EventTarget.Self), Event(EventTarget.Self, EventType.Removed)]
    public class DragComponent : IComponent
    {
    }
}