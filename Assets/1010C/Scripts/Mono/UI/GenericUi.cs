using System.Collections.Generic;
using UnityEngine;

namespace _1010C.Scripts.Mono.UI
{
    public abstract class GenericUi : MonoBehaviour
    {
        private List<GameEntity> _eventEntities = new List<GameEntity>();

        protected virtual void Start()
        {
            SubscribeToUiResetEvent();
            AddListeners();
        }

        private void SubscribeToUiResetEvent()
        {
//            GameController.Instance.ResetEvent += BaseRefresh;
        }

        protected abstract void AddListeners();

        private void BaseRefresh()
        {
            Refresh();
            AddListeners();
        }

        protected abstract void Refresh();
    }
}