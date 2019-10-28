using System.Collections;
using System.Collections.Generic;
using _1010C.Scripts.Misc;
using UnityEngine;

namespace _1010C.Scripts.PieceRecipes
{
    public abstract partial class PieceType : Enumeration
    {
        public static readonly PieceType onePiece = new OneType();
        public static readonly PieceType twoPieceVertical = TwoPieceType.mTwoPieceVertical;
        public static readonly PieceType twoPieceHorizontal = TwoPieceType.mTwoPieceHorizontal;
        public static readonly PieceType threePieceVertical = ThreePieceType.mThreePieceVertical;
        public static readonly PieceType threePieceHorizontal = ThreePieceType.mThreePieceHorizontal;
        public static readonly PieceType smallL1 = SmallLType.mSmallL1;
        public static readonly PieceType smallL2 = SmallLType.mSmallL2;
        public static readonly PieceType smallL3 = SmallLType.mSmallL3;
        public static readonly PieceType smallL4 = SmallLType.mSmallL4;
        public static readonly PieceType smallSquare = new SmallSquareType();

        private PieceType(int id, string name)
            : base(id, name)
        {
        }

        public abstract Vector2[] GetPiecePositions();
        public abstract float GetCubeSeparationAmount();

        public static PieceType GetNextPiece()
        {
            return GetAll<PieceType>().PickRandom();
        }
    }
}