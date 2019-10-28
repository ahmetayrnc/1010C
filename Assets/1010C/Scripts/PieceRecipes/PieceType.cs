using System.Collections;
using System.Collections.Generic;
using _1010C.Scripts.Misc;
using UnityEngine;

namespace _1010C.Scripts.PieceRecipes
{
    public abstract partial class PieceType : Enumeration
    {
        private PieceType(int id, string name)
            : base(id, name)
        {
        }

        public abstract Vector2[] GetPiecePositions();

        public static readonly PieceType onePiece = new OnePieceType();
        public static readonly PieceType twoPieceVertical = TwoPieceType.mTwoPieceVertical;
        public static readonly PieceType twoPieceHorizontal = TwoPieceType.mTwoPieceHorizontal;

        private class OnePieceType : PieceType
        {
            public OnePieceType() : base(0, "OnePiece")
            {
            }

            public override Vector2[] GetPiecePositions()
            {
                return new[] {Vector2.zero};
            }
        }

        private abstract class TwoPieceType : PieceType
        {
            public static readonly TwoPieceType mTwoPieceVertical = new TwoPieceVertical();
            public static readonly TwoPieceType mTwoPieceHorizontal = new TwoPieceHorizontal();

            private TwoPieceType(int value, string name) : base(value, name)
            {
            }

            private class TwoPieceVertical : TwoPieceType
            {
                public TwoPieceVertical() : base(1, "TwoPieceVertical")
                {
                }

                public override Vector2[] GetPiecePositions()
                {
                    return new[]
                    {
                        new Vector2(0, -0.5f),
                        new Vector2(0, +0.5f),
                    };
                }
            }

            private class TwoPieceHorizontal : TwoPieceType
            {
                public TwoPieceHorizontal() : base(2, "TwoPieceHorizontal")
                {
                }

                public override Vector2[] GetPiecePositions()
                {
                    return new[]
                    {
                        new Vector2(-0.5f, 0),
                        new Vector2(+0.5f, 0),
                    };
                }
            }
        }
    }
}