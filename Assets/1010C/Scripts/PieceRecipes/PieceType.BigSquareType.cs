using UnityEngine;

namespace _1010C.Scripts.PieceRecipes
{
    public abstract partial class PieceType
    {
        private class BigSquareType : PieceType
        {
            public BigSquareType() : base(18, "BigSquare")
            {
            }

            public override Vector2[] GetPiecePositions()
            {
                return new[]
                {
                    new Vector2(-1f, -1f),
                    new Vector2(-1f, +0f),
                    new Vector2(-1f, +1f),
                    new Vector2(+0f, -1f),
                    new Vector2(+0f, +0f),
                    new Vector2(+0f, +1f),
                    new Vector2(+1f, -1f),
                    new Vector2(+1f, +0f),
                    new Vector2(+1f, +1f),
                };
            }
        }
    }
}