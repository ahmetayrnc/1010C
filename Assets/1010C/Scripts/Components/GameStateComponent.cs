using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _1010C.Scripts.Components
{
    public enum GameState
    {
        Playing,
        Paused,
        Over
    }

    [Game, Unique, Event(EventTarget.Any)]
    public class GameStateComponent : IComponent
    {
        public GameState Value;
    }
}