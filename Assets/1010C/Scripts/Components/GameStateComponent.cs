using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _1010C.Scripts.Components
{
    public enum GameState
    {
        NotStarted,
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