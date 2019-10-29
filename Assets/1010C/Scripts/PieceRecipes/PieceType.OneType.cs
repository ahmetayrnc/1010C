using _1010C.Scripts.Components.Piece;
using UnityEngine;

namespace _1010C.Scripts.PieceRecipes
{
    public abstract partial class PieceType
    {
        private class OneType : PieceType
        {
            public OneType() : base(0, "One")
            {
            }
            
            public override float GetDragPivotDifference()
            {
                return 1.5f;
            }
            
            public override CubeColor GetCubeColor()
            {
                return CubeColor.Purple;
            }

            public override Vector2[] GetPiecePositions()
            {
                return new[] {Vector2.zero};
            }
        }
    }
}