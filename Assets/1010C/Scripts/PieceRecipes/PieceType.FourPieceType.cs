using UnityEngine;

namespace _1010C.Scripts.PieceRecipes
{
    public abstract partial class PieceType
    {
        private abstract class FourPieceType : PieceType
        {
            public static readonly FourPieceType mFourPieceVertical = new FourPieceVertical();
            public static readonly FourPieceType mFourPieceHorizontal = new FourPieceHorizontal();

            private FourPieceType(int value, string name) : base(value, name)
            {
            }

            private class FourPieceVertical : FourPieceType
            {
                public FourPieceVertical() : base(10, "FourPieceVertical")
                {
                }

                public override float GetDragPivotDifference()
                {
                    return 3f;
                }

                public override Vector2[] GetPiecePositions()
                {
                    return new[]
                    {
                        new Vector2(0, -1.5f),
                        new Vector2(0, -0.5f),
                        new Vector2(0, +0.5f),
                        new Vector2(0, +1.5f),
                    };
                }
            }

            private class FourPieceHorizontal : FourPieceType
            {
                public FourPieceHorizontal() : base(11, "FourPieceHorizontal")
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
                        new Vector2(-1.5f, 0),
                        new Vector2(-0.5f, 0),
                        new Vector2(+0.5f, 0),
                        new Vector2(+1.5f, 0),
                    };
                }
            }
        }
    }
}