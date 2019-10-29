using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _1010C.Scripts.Components.Cube
{
    public enum CubeState
    {
        Empty,
        Full
    }

    [Game, Event(EventTarget.Self)]
    public class CubeStateComponent : IComponent
    {
        public CubeState Value;
    } 
}