using _1010C.Scripts.PieceRecipes;
using UnityEngine;

namespace _1010C.Scripts.Services
{
    public class PieceCreationService : MonoBehaviour
    {
        public static void CreateReservePiece(GameEntity reserveSlot)
        {
            var piece = Contexts.sharedInstance.game.CreateEntity();
            piece.isPiece = true;
            piece.AddId(IdService.GetNewId());
            piece.AddPosition(reserveSlot.position.Value);
            piece.AddReserveSlotForPiece(reserveSlot.id.Value);
            piece.AddPieceCubePositions(PieceType.GetNextPiece().GetPiecePositions());

            reserveSlot.AddPieceInReserve(piece.id.Value);
        }
    }
}