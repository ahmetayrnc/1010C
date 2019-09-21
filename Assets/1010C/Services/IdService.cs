using UnityEngine;

namespace _1010C.Services
{
    public class IdService : MonoBehaviour
    {
        public static int GetNewId()
        {
            var game = Contexts.sharedInstance.game;
            var newId = game.idCount.Value;
            game.idCount.Value++;
            return newId;
        }
    }
}