using _1010C.Scripts.Components.Piece;
using _1010C.Scripts.PieceRecipes;
using UnityEngine;

namespace _1010C.Scripts.Services
{
    public class PieceCreationService : MonoBehaviour
    {
        public static void CreateReservePiece(GameEntity reserveSlot)
        {
            var pieceType = PieceType.GetNextPiece();
            var piece = Contexts.sharedInstance.game.CreateEntity();
            var pieceColor = (CubeColor) Random.Range(0, System.Enum.GetValues(typeof(CubeColor)).Length);

            piece.isPiece = true;
            piece.AddId(IdService.GetNewId());
            piece.AddPosition(reserveSlot.position.Value);
            piece.AddReserveSlotForPiece(reserveSlot.id.Value);
            piece.AddPieceType(pieceType);
            piece.AddColor(pieceColor);

            reserveSlot.AddPieceInReserve(piece.id.Value);
        }
    }
}