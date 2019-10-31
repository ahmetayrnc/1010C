using _1010C.Scripts.Components;
using TMPro;
using UnityEngine;

namespace _1010C.Scripts.Mono.UI
{
    public class GameOverUi : GenericUi, IAnyGameStateListener
    {
        public TextMeshProUGUI scoreText;
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
            container.SetActive(value == GameState.Over);
            scoreText.text = Contexts.sharedInstance.game.score.Value.ToString();
        }
    }
}