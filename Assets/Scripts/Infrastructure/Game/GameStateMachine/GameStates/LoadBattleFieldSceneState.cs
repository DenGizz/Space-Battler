using System.Collections;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.Game.GameStateMachine.GameStates
{
    public class LoadBattleFieldSceneState : IState
    {
        private readonly GameStateMachine GameStateMachine;
        private readonly ScenesConfig _scenesConfig;
        private readonly ISceneLoader _sceneLoader;

        public LoadBattleFieldSceneState(GameStateMachine gameStateMachine, ScenesConfig scenesConfig, ISceneLoader sceneLoader)
        {
            GameStateMachine = gameStateMachine;
            _scenesConfig = scenesConfig;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadSceneAsync
                (_scenesConfig.BattleFieldSceneName, 
                () => GameStateMachine.EnterState<CreateBattleState>());
        }

        public void Exit()
        {

        }
    }
}