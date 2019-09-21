using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _1010C.Scripts.Components
{
    [Game, Unique]
    public class IdCountComponent : IComponent
    {
        public int Value;
    }
}