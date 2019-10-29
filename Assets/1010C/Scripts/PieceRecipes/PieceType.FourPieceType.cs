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

            public override float GetCubeSeparationAmount()
            {
                return 0.086f;
            }

            private class FourPieceVertical : FourPieceType
            {
                public FourPieceVertical() : base(10, "FourPieceVertical")
                {
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