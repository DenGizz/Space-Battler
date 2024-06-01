using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Gameplay.Configs;
using Assets.Scripts.StateMachines;

namespace Assets.Scripts.Game.GameStates
{
    public class LoadMainMenuSceneState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ScenesConfig _scenesConfig;

        public LoadMainMenuSceneState(StateMachine stateMachine, ISceneLoader sceneLoader, ScenesConfig scenesConfig)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _scenesConfig = scenesConfig;
        }

        public void Enter()
        {
            _sceneLoader.LoadSceneAsync(_scenesConfig.MainMenuSceneName, 
                () => _stateMachine.EnterState<MainMenuState>());
        }

        public void Exit()
        {

        }
    }
}