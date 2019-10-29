using TMPro;

namespace _1010C.Scripts.Mono.UI
{
    public class ScoreUi : GenericUi, IAnyScoreListener
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
    }
}