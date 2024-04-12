using System.Diagnostics;
using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.SpaceShips;
using Assets.Scripts.StateMachines;

namespace Assets.Scripts.Game.GameStates
{
    public class BattleState : IState, IStateWithArtuments<Battle>
    {
        private readonly IBattleObserver _battleObserver;
        private readonly IUiFactory _uiFactory;
        private readonly StateMachine _gameStateMachine;
        private readonly IBattleTickService _battleTickService;
        private readonly IBattleUiService _battleUiService;

        private Battle _battle;

        public BattleState(StateMachine gameStateMachine, IBattleObserver battleObserver, IUiFactory uiFactory, IBattleTickService battleTickService, IBattleUiService battleUIService)
        {
            _gameStateMachine = gameStateMachine;
            _battleObserver = battleObserver;
            _uiFactory = uiFactory;
            _battleTickService = battleTickService;
            _battleUiService = battleUIService;
        }

        public void Enter()
        {

        }

        public void Enter(Battle args)
        {
            _battle = args;
            _battle.StartBattle();
            _battleTickService.IsPaused = false;
            PauseResumeUI pauseMenu = _uiFactory.CreatePauseResumeUi();
            pauseMenu.OnPauseContinueButtonClicked += OnPauseContinueButtonClicked;

            _battleObserver.StartObserve(_battle);
            _battleObserver.OnWinnerDetermined += OnWinnerDeterminedEventHandler;
        }

        public void Exit()
        {
            _battleObserver.OnWinnerDetermined -= OnWinnerDeterminedEventHandler;
            _battleUiService.BattleUi.OnReturnToMainMenuButtonClicked -= OnPauseMenuReturnToMainMenuButtonClicked;

        }

        private void OnWinnerDeterminedEventHandler(ISpaceShip winner)
        {
            _battle.StopBattle();
            _battleObserver.StopObserve();
            _battleUiService.BattleUi.HideBattleView();
            _battleUiService.BattleUi.ShowWinner(winner, _battle.BattleData.PlayerSpaceShip == winner);
            _battleTickService.IsPaused = true;

            _battleUiService.BattleUi.OnReturnToMainMenuButtonClicked += OnPauseMenuReturnToMainMenuButtonClicked;
        }

        private void OnPauseContinueButtonClicked()
        {
            if (_battle.IsBattleActive)
            {
                _battleTickService.IsPaused = true;
                _battle.StopBattle();
            }   
            else
            {
                _battleTickService.IsPaused = false;
                _battle.ResumeBattle();
            }
        }

        private void OnPauseMenuReturnToMainMenuButtonClicked()
        {
            _gameStateMachine.EnterState<CleanUpBattleState, Battle>(_battle);
        }
    }
}
