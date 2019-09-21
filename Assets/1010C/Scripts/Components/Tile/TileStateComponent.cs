using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _1010C.Scripts.Components.Tile
{
    public enum TileState
    {
        Empty,
        Full
    }

    [Game, Event(EventTarget.Self)]
    public class TileStateComponent : IComponent
    {
        public TileState Value;
    } 
}