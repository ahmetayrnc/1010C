using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _1010C.Scripts.Components
{
    public enum GameState
    {
        Playing,
        Over
    }

    [Game, Unique, Event(EventTarget.Self)]
    public class GameStateComponent : IComponent
    {
        public GameState Value;
    }
}