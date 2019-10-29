using _1010C.Scripts.Components.Piece;
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
        public static readonly PieceType fourPieceVertical = FourPieceType.mFourPieceVertical;
        public static readonly PieceType fourPieceHorizontal = FourPieceType.mFourPieceHorizontal;
        public static readonly PieceType bigL1 = BigLType.mBigL1;
        public static readonly PieceType bigL2 = BigLType.mBigL2;
        public static readonly PieceType bigL3 = BigLType.mBigL3;
        public static readonly PieceType bigL4 = BigLType.mBigL4;
        public static readonly PieceType fivePieceVertical = FivePieceType.mFivePieceVertical;
        public static readonly PieceType fivePieceHorizontal = FivePieceType.mFivePieceHorizontal;
        public static readonly PieceType bigSquare = new BigSquareType();

        private PieceType(int id, string name)
            : base(id, name)
        {
        }

        public abstract Vector2[] GetPiecePositions();

        public abstract float GetDragPivotDifference();

        public abstract CubeColor GetCubeColor();

        public static PieceType GetNextPiece()
        {
            return GetAll<PieceType>().PickRandom();
        }
    }
}