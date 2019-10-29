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

            public override float GetCubeSeparationAmount()
            {
                return 0.086f;
            }
        }
    }
}