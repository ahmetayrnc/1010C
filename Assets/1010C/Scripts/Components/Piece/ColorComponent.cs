using Entitas;

namespace _1010C.Scripts.Components.Piece
{
    [Game]
    public class ColorComponent : IComponent
    {
        public CubeColor Value;
    }

    public enum CubeColor
    {
        Color0,
        Color1,
        Color2,
        Color3,
        Color4,
        Color5,
        Color6,
        Color7,
    }
}