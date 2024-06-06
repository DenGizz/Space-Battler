using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.SandboxMode.Services;
using Assets.Scripts.Infrastructure.Ui.Factories;
using Assets.Scripts.Infrastructure.Ui.Providers;
using Assets.Scripts.StateMachines;
using Assets.Scripts.UI.Uis;
using Assets.Scripts.UI.UiScreens.SandboxModeUiScreens;
using UnityEngine;

namespace Assets.Scripts.Game.GameStates.SandboxLoopStates
{
    public class ShowWinnerState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IBattleRunnerProvider _battleRunnerProvider;
        private readonly IUisProvider _uisProvider;
        private readonly IHUDsProvider _hudsProvider;


        public ShowWinnerState(StateMachine stateMachine, IBattleRunnerProvider battleRunnerProvider, IUiElementsFactory uiFactory, IUisProvider uisProvider, IHUDsProvider hudsProvider)
        {
            _stateMachine = stateMachine;
            _battleRunnerProvider = battleRunnerProvider;
            _uisProvider = uisProvider;
            _hudsProvider = hudsProvider;
        }

        public void Enter()
        {
            GameObject.Destroy(_hudsProvider.PauseBattleHUD.gameObject);
            _hudsProvider.PauseBattleHUD = null;
            BattleRunner battleRunner = _battleRunnerProvider.CurrentBattleRunner;

            _uisProvider.SandboxModeUi
                .GoToScreen<SandboxBattleEndStatsUiScreen>()
                .SetBattleResult(battleRunner.ThisBattleResult.Value);

            _uisProvider.SandboxModeUi.OnGameStateChangeEvent += OnReturnMainMenuButtonPressedEventHandler;
        }

        public void Exit()
        {
            _uisProvider.SandboxModeUi.OnGameStateChangeEvent -= OnReturnMainMenuButtonPressedEventHandler;
        }

        private void OnReturnMainMenuButtonPressedEventHandler(GameStateChangeEvent @event)
        {
            if (@event != GameStateChangeEvent.CloseBattleEndScreen)
                return;

            _stateMachine.EnterState<CleanUpBattleState>();
        }
    }
}