using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _1010C.Scripts.Components.Piece
{
    [Game, Unique]
    public class PieceInAirComponent : IComponent
    {
        public int Id;
    }
}