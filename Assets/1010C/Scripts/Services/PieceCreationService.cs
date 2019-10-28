using _1010C.Scripts.Components.Piece;
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
            piece.AddPieceCubePositions(new[]
            {
                new Vector2Int(-1, -1),
                new Vector2Int(0, -1),
                new Vector2Int(1, -1),
                new Vector2Int(-1, 0),
                new Vector2Int(0, 0),
                new Vector2Int(1, 0),
                new Vector2Int(-1, 1),
                new Vector2Int(0, 1),
                new Vector2Int(1, 1),
            });

            reserveSlot.AddPieceInReserve(piece.id.Value);
        }
    }
}