using System.Collections;
using Assets.Scripts.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.Game.GameStateMachine.GameStates
{
    public class LoadBattleFieldSceneState : IState
    {
        private readonly GameStateMachine GameStateMachine;
        private readonly ScenesConfig _scenesConfig;

        public LoadBattleFieldSceneState(GameStateMachine gameStateMachine, ScenesConfig scenesConfig)
        {
            GameStateMachine = gameStateMachine;
            _scenesConfig = scenesConfig;
        }

        public void Enter()
        {
            SceneManager.LoadScene(_scenesConfig.BattleFieldSceneName, LoadSceneMode.Single);
            GameStateMachine.EnterState<CreateBattleState>();
        }

        public void Exit()
        {

        }
    }
}