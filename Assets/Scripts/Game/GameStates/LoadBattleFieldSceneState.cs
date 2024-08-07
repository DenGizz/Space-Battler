﻿using Assets.Scripts.Game.GameStates.SandboxLoopStates;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Gameplay.Configs;
using Assets.Scripts.StateMachines;

namespace Assets.Scripts.Game.GameStates
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
                (_scenesConfig.SandboxModeSceneName, 
                () => _stateMachine.EnterState<InitializeSandboxModeState>());
        }

        public void Exit()
        {

        }
    }
}