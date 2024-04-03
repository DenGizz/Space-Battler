using Assets.Scripts.Game.GameStateMachine.GameStates;
using Zenject;

namespace Assets.Scripts.Game
{
    public class Game
    {
        private readonly GameStateMachine.GameStateMachine _gameStateMachine;

        [Inject]
        public Game(GameStateMachine.GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Start()
        {
            _gameStateMachine.EnterState<LoadMainMenuSceneState>();
        }
    }
}