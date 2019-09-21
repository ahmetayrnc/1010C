using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace _1010C.Mono.View
{
    public abstract class View : MonoBehaviour
    {
        protected const string TileLayer = "Tile";
        protected const string CubeLayer = "Cube";
        protected const string PieceLayer = "Piece";
        
        public void Link(IEntity entity)
        {
            gameObject.Link(entity);
            var ge = (GameEntity) entity;
            AddListeners(ge);
            InitializeView(ge);
        }

        protected abstract void AddListeners(GameEntity entity);

        protected abstract void InitializeView(GameEntity entity);
    }
}