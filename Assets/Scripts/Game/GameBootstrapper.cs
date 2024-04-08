using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game
{
    [AddComponentMenu("Infrastructure/GameBootstrapper")]
    public class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        [Inject]
        public void Construct(Game game)
        {
            _game = game;
            DontDestroyOnLoad(this);
        }

        private void LunchGame()
        {
            _game.Start();
        }

        private void Awake()
        {
            LunchGame();
        }
    }
}