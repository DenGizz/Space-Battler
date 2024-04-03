using Assets.Scripts.Infrastructure.Config;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.StateMachine;

namespace Assets.Scripts.Game.GameStateMachine.GameStates
{
    public class LoadMainMenuSceneState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ScenesConfig _scenesConfig;

        public LoadMainMenuSceneState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader, ScenesConfig scenesConfig)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _scenesConfig = scenesConfig;
        }

        public void Enter()
        {
            _sceneLoader.LoadSceneAsync(_scenesConfig.MainMenuSceneName, 
                () => _gameStateMachine.EnterState<MainMenuState>());
        }

        public void Exit()
        {

        }
    }
}