using _1010C.Scripts.Components.Piece;
using UnityEngine;

namespace _1010C.Scripts.PieceRecipes
{
    public abstract partial class PieceType
    {
        private abstract class ThreePieceType : PieceType
        {
            public static readonly ThreePieceType mThreePieceVertical = new ThreePieceVertical();
            public static readonly ThreePieceType mThreePieceHorizontal = new ThreePieceHorizontal();

            private ThreePieceType(int value, string name) : base(value, name)
            {
            }
            
            public override CubeColor GetCubeColor()
            {
                return CubeColor.Orange;
            }

            private class ThreePieceVertical : ThreePieceType
            {
                public ThreePieceVertical() : base(3, "ThreePieceVertical")
                {
                }
                
                public override float GetDragPivotDifference()
                {
                    return 2.5f;
                }

                public override Vector2[] GetPiecePositions()
                {
                    return new[]
                    {
                        new Vector2(0, -1),
                        new Vector2(0, 0),
                        new Vector2(0, +1),
                    };
                }
            }

            private class ThreePieceHorizontal : ThreePieceType
            {
                public ThreePieceHorizontal() : base(4, "ThreePieceHorizontal")
                {
                }
                
                public override float GetDragPivotDifference()
                {
                    return 1.5f;
                }

                public override Vector2[] GetPiecePositions()
                {
                    return new[]
                    {
                        new Vector2(-1, 0),
                        new Vector2(0, 0),
                        new Vector2(+1f, 0),
                    };
                }
            }
        }
    }
}