using UnityEngine;

namespace _1010C.Scripts.PieceRecipes
{
    public abstract partial class PieceType
    {
        private abstract class BigLType : PieceType
        {
            public static readonly BigLType mBigL1 = new BigL1();
            public static readonly BigLType mBigL2 = new BigL2();
            public static readonly BigLType mBigL3 = new BigL3();
            public static readonly BigLType mBigL4 = new BigL4();

            private BigLType(int value, string name) : base(value, name)
            {
            }

            private class BigL1 : BigLType
            {
                public BigL1() : base(12, "BigL1")
                {
                }

                public override Vector2[] GetPiecePositions()
                {
                    return new[]
                    {
                        new Vector2(-1f, -1f),
                        new Vector2(+0f, -1f),
                        new Vector2(+1f, -1f),
                        new Vector2(-1f, +0f),
                        new Vector2(-1f, +1f),
                    };
                }
            }

            private class BigL2 : BigLType
            {
                public BigL2() : base(13, "BigL2")
                {
                }

                public override Vector2[] GetPiecePositions()
                {
                    return new[]
                    {
                        new Vector2(-1f, -1f),
                        new Vector2(+0f, -1f),
                        new Vector2(+1f, -1f),
                        new Vector2(+1f, +0f),
                        new Vector2(+1f, +1f),
                    };
                }
            }

            private class BigL3 : BigLType
            {
                public BigL3() : base(14, "BigL3")
                {
                }

                public override Vector2[] GetPiecePositions()
                {
                    return new[]
                    {
                        new Vector2(-1f, +1f),
                        new Vector2(+0f, +1f),
                        new Vector2(+1f, +1f),
                        new Vector2(-1f, +0f),
                        new Vector2(-1f, -1f),
                    };
                }
            }

            private class BigL4 : BigLType
            {
                public BigL4() : base(15, "BigL4")
                {
                }

                public override Vector2[] GetPiecePositions()
                {
                    return new[]
                    {
                        new Vector2(-1f, +1f),
                        new Vector2(+0f, +1f),
                        new Vector2(+1f, +1f),
                        new Vector2(+1f, +0f),
                        new Vector2(+1f, -1f),
                    };
                }
            }
        }
    }
}