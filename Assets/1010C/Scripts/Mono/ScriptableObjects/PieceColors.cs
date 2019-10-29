using _1010C.Scripts.Components.Piece;
using UnityEngine;

namespace _1010C.Scripts.Mono.ScriptableObjects
{
    [CreateAssetMenu]
    public class PieceColors : ScriptableObject
    {
        public Color[] colors;

        public Color CubeColorToColor(CubeColor cubeColor)
        {
            switch (cubeColor)
            {
                case CubeColor.Purple:
                    return colors[0];
                case CubeColor.Yellow:
                    return colors[1];
                case CubeColor.DarkGreen:
                    return colors[2];
                case CubeColor.Orange:
                    return colors[3];
                case CubeColor.LightGreen:
                    return colors[4];
                case CubeColor.Pink:
                    return colors[5];
                case CubeColor.Red:
                    return colors[6];
                case CubeColor.Blue:
                    return colors[7];
                case CubeColor.Cyan:
                    return colors[8];
                default:
                    return colors[0];
            }
        }
    }
}