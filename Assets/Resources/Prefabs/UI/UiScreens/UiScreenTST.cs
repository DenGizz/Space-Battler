using Assets.Scripts.Game.GameStates;
using Assets.Scripts.StateMachines;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UI;
using Zenject;




public class SimpleState : IState
{
    StateMachine _stateMachine;
    MainUiTest _mainMenu;
    public void Enter()
    {
        _mainMenu = new MainUiTest();
        _mainMenu.OnGameStateChangeEvent += OnGameStateChange;
        _mainMenu.GoToScreen<SandboxBattleSetupUiScreentst>();
    }

    public void Exit()
    {
        _mainMenu = null;
        _mainMenu.OnGameStateChangeEvent -= OnGameStateChange;
    }


    private void OnGameStateChange(IGameStateChangeEvent gameState)
    {
        switch (gameState)
        {
            case IGameStateChangeEvent.EnterSandboxMode:
                _stateMachine.EnterState<SandboxModeLoopState>();
                break;
            default:
                break;
        }
    }
}
