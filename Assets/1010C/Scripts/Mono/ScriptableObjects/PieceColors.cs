using _1010C.Scripts.Components.Piece;
using UnityEngine;

namespace _1010C.Scripts.Mono.ScriptableObjects
{
    [CreateAssetMenu]
    public class PieceColors : ScriptableObject
    {
        public Color[] colors;

        public Color PieceColorToColor(CubeColor cubeColor)
        {
            switch (cubeColor)
            {
                case CubeColor.Color0:
                    return colors[0];
                case CubeColor.Color1:
                    return colors[1];
                case CubeColor.Color2:
                    return colors[2];
                case CubeColor.Color3:
                    return colors[3];
                case CubeColor.Color4:
                    return colors[4];
                case CubeColor.Color5:
                    return colors[5];
                case CubeColor.Color6:
                    return colors[6];
                case CubeColor.Color7:
                    return colors[7];
                default:
                    return colors[0];
            }
        }
    }
}