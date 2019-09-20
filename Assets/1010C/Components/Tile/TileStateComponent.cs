using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace _1010C.Components.Tile
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