using _1010C.Scripts.Components;
using UnityEngine;

namespace _1010C.Scripts.Mono.UI
{
    public class PauseUi : GenericUi, IAnyGameStateListener
    {
        public GameObject container;

        protected override void AddListeners()
        {
            Contexts.sharedInstance.game.CreateEntity().AddAnyGameStateListener(this);
        }

        protected override void Refresh()
        {
        }

        public void OnAnyGameState(GameEntity entity, GameState value)
        {
            container.SetActive(value == GameState.Paused);
        }

        public void ResumeGame()
        {
            Contexts.sharedInstance.game.ReplaceGameState(GameState.Playing);
        }

        public void RestartGame()
        {
        }

        public void ReturnToMenu()
        {
        }
    }
}