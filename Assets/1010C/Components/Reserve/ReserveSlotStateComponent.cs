using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace _1010C.Components.Reserve
{
    public enum ReserveSlotState
    {
        Empty,
        Full
    }

    [Game, Event(EventTarget.Self)]
    public class ReserveSlotStateComponent : IComponent
    {
        public ReserveSlotState Value;
    }
}