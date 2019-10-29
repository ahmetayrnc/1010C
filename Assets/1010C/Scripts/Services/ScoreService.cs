namespace _1010C.Scripts.Services
{
    public class ScoreService
    {
        public static void IncrementScore(int amount)
        {
            var oldScore = Contexts.sharedInstance.game.score.Value;
            var newScore = oldScore + amount;
            Contexts.sharedInstance.game.ReplaceScore(newScore);
        }
    }
}