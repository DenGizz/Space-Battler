using Assets.Scripts.Battles;
using Assets.Scripts.Battles.BattleRun;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.UiInfrastructure;
using Assets.Scripts.StateMachines;
using Assets.Scripts.UI.BattleUI;
using Assets.Scripts.UI.NewUi.Uis;

namespace Assets.Scripts.Game.GameStates
{
    public class ShowWinnerState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IBattleRunnerProvider _battleRunnerProvider;
        private readonly IUisProvider _uisProvider;


        public ShowWinnerState(StateMachine stateMachine, IBattleRunnerProvider battleRunnerProvider, IUiElementsFactory uiFactory, IUisProvider uisProvider)
        {
            _stateMachine = stateMachine;
            _battleRunnerProvider = battleRunnerProvider;
            _uisProvider = uisProvider;
        }

        public void Enter()
        {
            BattleRunner battleRunner = _battleRunnerProvider.CurrentBattleRunner;

            _uisProvider.SandboxModeUi.GoToScreen<SandboxBattleEndStatsUiScreen>();
            _uisProvider.SandboxModeUi.OnGameStateChangeEvent += OnReturnMainMenuButtonPressedEventHandler;
        }

        public void Exit()
        {
         
        }

        private void OnReturnMainMenuButtonPressedEventHandler(GameStateChangeEvent @event)
        {
            if (@event != GameStateChangeEvent.CloseBattleEndScreen)
                return;

            _stateMachine.EnterState<CleanUpBattleState>();
        }
    }
}