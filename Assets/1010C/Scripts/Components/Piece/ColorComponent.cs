using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _1010C.Scripts.Components.Piece
{
    [Game, Event(EventTarget.Self)]
    public class ColorComponent : IComponent
    {
        public CubeColor Value;
    }

    public enum CubeColor
    {
        Purple,
        Yellow,
        DarkGreen,
        Orange,
        LightGreen,
        Pink,
        Red,
        Blue,
        Cyan,
    }
}