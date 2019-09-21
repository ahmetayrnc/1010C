using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _1010C.Scripts.Components
{
    [Game]
    public class IdComponent : IComponent
    {
        [PrimaryEntityIndex] public int Value;
    }
}