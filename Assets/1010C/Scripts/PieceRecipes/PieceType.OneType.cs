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

            public override Vector2[] GetPiecePositions()
            {
                return new[] {Vector2.zero};
            }

            public override float GetCubeSeparationAmount()
            {
                return 0.172f;
            }
        }
    }
}