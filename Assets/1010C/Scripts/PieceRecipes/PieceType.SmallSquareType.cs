using _1010C.Scripts.Components.Piece;
using UnityEngine;

namespace _1010C.Scripts.PieceRecipes
{
    public abstract partial class PieceType
    {
        private class SmallSquareType : PieceType
        {
            public SmallSquareType() : base(9, "SmallSquare")
            {
            }
            
            public override float GetDragPivotDifference()
            {
                return 2f;
            }
            
            public override CubeColor GetCubeColor()
            {
                return CubeColor.LightGreen;
            }

            public override Vector2[] GetPiecePositions()
            {
                return new[]
                {
                    new Vector2(-0.5f, -0.5f),
                    new Vector2(+0.5f, -0.5f),
                    new Vector2(-0.5f, +0.5f),
                    new Vector2(+0.5f, +0.5f),
                };
            }
        }
    }
}