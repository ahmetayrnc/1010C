using UnityEngine;

namespace _1010C.Scripts.PieceRecipes
{
    public abstract partial class PieceType
    {
        private abstract class SmallLType : PieceType
        {
            public static readonly SmallLType mSmallL1 = new SmallL1();
            public static readonly SmallLType mSmallL2 = new SmallL2();
            public static readonly SmallLType mSmallL3 = new SmallL3();
            public static readonly SmallLType mSmallL4 = new SmallL4();

            private SmallLType(int value, string name) : base(value, name)
            {
            }
            
            public override float GetDragPivotDifference()
            {
                return 2f;
            }

            private class SmallL1 : SmallLType
            {
                public SmallL1() : base(5, "SmallL1")
                {
                }

                public override Vector2[] GetPiecePositions()
                {
                    return new[]
                    {
                        new Vector2(-0.5f, -0.5f),
                        new Vector2(+0.5f, -0.5f),
                        new Vector2(-0.5f, +0.5f),
                    };
                }
            }

            private class SmallL2 : SmallLType
            {
                public SmallL2() : base(6, "SmallL2")
                {
                }

                public override Vector2[] GetPiecePositions()
                {
                    return new[]
                    {
                        new Vector2(-0.5f, -0.5f),
                        new Vector2(+0.5f, -0.5f),
                        new Vector2(+0.5f, +0.5f),
                    };
                }
            }

            private class SmallL3 : SmallLType
            {
                public SmallL3() : base(7, "SmallL3")
                {
                }

                public override Vector2[] GetPiecePositions()
                {
                    return new[]
                    {
                        new Vector2(-0.5f, -0.5f),
                        new Vector2(-0.5f, +0.5f),
                        new Vector2(+0.5f, +0.5f),
                    };
                }
            }

            private class SmallL4 : SmallLType
            {
                public SmallL4() : base(8, "SmallL4")
                {
                }

                public override Vector2[] GetPiecePositions()
                {
                    return new[]
                    {
                        new Vector2(+0.5f, -0.5f),
                        new Vector2(-0.5f, +0.5f),
                        new Vector2(+0.5f, +0.5f),
                    };
                }
            }
        }
    }
}