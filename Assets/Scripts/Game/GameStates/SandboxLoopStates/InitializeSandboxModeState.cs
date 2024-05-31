﻿using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.CoreServices.PersistentDataServices;
using Assets.Scripts.Infrastructure.UiInfrastructure;
using Assets.Scripts.StateMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game.GameStates.SandboxLoopStates
{
    public class InitializeSandboxModeState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IUiFactory _uiFactory;
        private readonly IUisProvider _uisProvider;

        public InitializeSandboxModeState(IStateMachine stateMachine, IUiFactory uiFactory, IUisProvider uisProvider)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _uisProvider = uisProvider;
        }

        public void Enter()
        {
            var _sandboxUi = _uiFactory.CreateSandboxBattleUi();
            _uisProvider.SandboxModeUi = _sandboxUi;
            _stateMachine.EnterState<EditBattleSetupState>();
        }

        public void Exit(){}
    }
}
