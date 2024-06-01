﻿using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.StateMachines;
using Assets.Scripts.UI.NewUi.Uis;
using Assets.Scripts.UI.NewUi.UiScreens.MainMenuUiScreens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Infrastructure.Core.Services.PersistentDataServices;
using Assets.Scripts.Infrastructure.SandboxMode.Services;
using Assets.Scripts.Infrastructure.Ui.Providers;

namespace Assets.Scripts.Game.GameStates.SandboxLoopStates
{
    public class EditBattleSetupState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IBattleSetupProvider _battleSetupProvider;
        private readonly IPersistentDataService _persistentDataService;
        private readonly IUisProvider _uisProvider;

        private Ui _sandboxUi;


        private SetupSandboxBattleUiScreen _sandboxScreen;

        public EditBattleSetupState(StateMachine stateMachine, IBattleSetupProvider battleSetupProvider,
            IPersistentDataService persistentDataService, IUisProvider uisProvider)
        {
            _stateMachine = stateMachine;
            _battleSetupProvider = battleSetupProvider;
            _persistentDataService = persistentDataService;
            _uisProvider = uisProvider;
        }


        public void Enter()
        {
            _sandboxUi = _uisProvider.SandboxModeUi;
            _sandboxScreen = _sandboxUi.GoToScreen<SetupSandboxBattleUiScreen>();
            _sandboxScreen.SetBattleSetupForEditing(_battleSetupProvider.BattleSetup);
            _sandboxUi.OnGameStateChangeEvent += OnGameStateChangeUiEventHandler;// TODO: Use Task and async/await
        }

        public void Exit()
        {
            _sandboxUi.OnGameStateChangeEvent -= OnGameStateChangeUiEventHandler;
        }

        private void OnGameStateChangeUiEventHandler(GameStateChangeEvent @event)
        {
            if (@event != GameStateChangeEvent.StartSandboxBattle)
                return;

            _persistentDataService.SaveBattleSetup(_battleSetupProvider.BattleSetup);
            _stateMachine.EnterState<CreateBattleState>();
        }
    }
}
