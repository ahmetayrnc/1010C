using _1010C.Scripts.Components;
using TMPro;
using UnityEngine;

namespace _1010C.Scripts.Mono.UI
{
    public class MenuUi : GenericUi, IAnyGameStateListener, IAnyBestScoreListener
    {
        public GameObject container;
        public TextMeshProUGUI bestScoreText;

        protected override void AddListeners()
        {
            Contexts.sharedInstance.game.CreateEntity().AddAnyGameStateListener(this);
            Contexts.sharedInstance.game.CreateEntity().AddAnyBestScoreListener(this);
        }

        protected override void Refresh()
        {
        }

        public void OnAnyGameState(GameEntity entity, GameState value)
        {
            container.SetActive(value == GameState.NotStarted);
        }

        public void OnAnyBestScore(GameEntity entity, int value)
        {
            bestScoreText.text = value.ToString();
        }

        public void StartGame()
        {
        }
    }
}