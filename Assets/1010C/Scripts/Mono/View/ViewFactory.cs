using UnityEngine;

namespace _1010C.Scripts.Mono.View
{
    public class ViewFactory : MonoBehaviour
    {
        private static ViewFactory _inst;

        private static ViewFactory Instance
        {
            get
            {
                if (_inst) return _inst;

                _inst = FindObjectOfType<ViewFactory>();
                Debug.Assert(_inst != null, "No ViewFactory in scene");

                return _inst;
            }
        }

        public GameObject cubeView;
        public GameObject tileView;
        public GameObject pieceView;

        public static GameObject SpawnCube()
        {
            return Instance.SpawnCubeInternal();
        }
        
        public static GameObject SpawnTile()
        {
            return Instance.SpawnTileInternal();
        }
        
        public static GameObject SpawnPiece()
        {
            return Instance.SpawnPieceInternal();
        }

        private GameObject SpawnCubeInternal()
        {
            return Instantiate(cubeView, transform);
        }
        
        private GameObject SpawnTileInternal()
        {
            return Instantiate(tileView, transform);
        }
        
        private GameObject SpawnPieceInternal()
        {
            return Instantiate(pieceView, transform);
        }
    }
}