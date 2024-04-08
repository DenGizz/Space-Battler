using Assets.Scripts.Infrastructure.Config;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.StateMachines;

namespace Assets.Scripts.Game.GameStateMachine.GameStates
{
    public class LoadBattleFieldSceneState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly ScenesConfig _scenesConfig;
        private readonly ISceneLoader _sceneLoader;

        public LoadBattleFieldSceneState(StateMachine stateMachine, ScenesConfig scenesConfig, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _scenesConfig = scenesConfig;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadSceneAsync
                (_scenesConfig.BattleFieldSceneName, 
                () => _stateMachine.EnterState<CreateBattleState>());
        }

        public void Exit()
        {

        }
    }
}