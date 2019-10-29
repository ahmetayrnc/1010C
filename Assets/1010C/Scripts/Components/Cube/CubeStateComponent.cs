using Entitas;

namespace _1010C.Scripts.Components.Cube
{
    public enum CubeState
    {
        Empty,
        Full
    }

    [Game]
    public class CubeStateComponent : IComponent
    {
        public CubeState Value;
    }
}