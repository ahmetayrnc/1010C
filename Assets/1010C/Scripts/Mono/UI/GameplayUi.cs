using _1010C.Scripts.Components;
using TMPro;

namespace _1010C.Scripts.Mono.UI
{
    public class GameplayUi : GenericUi, IAnyScoreListener
    {
        public TextMeshProUGUI scoreText;

        protected override void AddListeners()
        {
            Contexts.sharedInstance.game.CreateEntity().AddAnyScoreListener(this);
        }

        protected override void Refresh()
        {
        }

        public void OnAnyScore(GameEntity entity, int value)
        {
            scoreText.text = value.ToString();
        }

        public void PauseGame()
        {
            Contexts.sharedInstance.game.ReplaceGameState(GameState.Paused);
        }
    }
}