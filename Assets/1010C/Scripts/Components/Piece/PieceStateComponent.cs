using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _1010C.Scripts.Components.Piece
{
    public enum PieceState
    {
        InReserve,
        InAir,
    }

    [Game, Event(EventTarget.Self)]
    public class PieceStateComponent : IComponent
    {
        public PieceState Value;
    }
}