using Assets.Scripts.Battles;
using Assets.Scripts.Battles.BattleRun;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.StateMachines;
using Assets.Scripts.UI.BattleUI;

namespace Assets.Scripts.Game.GameStates
{
    public class ShowWinnerState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IBattleRunnerProvider _battleRunnerProvider;
        private readonly IUiElementsFactory _uiFactory;

        private BattleWinnerViewModel _winnerViewModel;

        public ShowWinnerState(StateMachine stateMachine, IBattleRunnerProvider battleRunnerProvider, IUiElementsFactory uiFactory)
        {
            _stateMachine = stateMachine;
            _battleRunnerProvider = battleRunnerProvider;
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            BattleRunner battleRunner = _battleRunnerProvider.CurrentBattleRunner;
            _winnerViewModel = _uiFactory.CreateWinnerUi();
            _winnerViewModel.SetWinner(battleRunner.ThisBattleResult.Value);
            _winnerViewModel.OnReturnMainMenuButtonPressed += OnReturnMainMenuButtonPressedEventHandler;
        }

        public void Exit()
        {
            _winnerViewModel.OnReturnMainMenuButtonPressed -= OnReturnMainMenuButtonPressedEventHandler;
        }

        private void OnReturnMainMenuButtonPressedEventHandler()
        {
            _stateMachine.EnterState<CleanUpBattleState>();
        }
    }
}