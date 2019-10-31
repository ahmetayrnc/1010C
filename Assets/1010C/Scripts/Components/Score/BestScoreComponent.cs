using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _1010C.Scripts.Components.Score
{
    [Game, Unique, Event(EventTarget.Any)]
    public class BestScoreComponent : IComponent
    {
        public int Value;
    }
}