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
    public class BattleState : IState
    {
        private readonly IBattleObserver _battleObserver;
        private readonly IUiFactory _uiFactory;
        private readonly IBattleTickService _battleTickService;
        private readonly IBattleUiService _battleUiService;
        private readonly IBattleProvider _battleProvider;

        private readonly StateMachine _gameStateMachine;
        private Battle _battle;
        private PauseResumeUI _pauseResumeUi;

        public BattleState(StateMachine gameStateMachine, IBattleObserver battleObserver, 
            IUiFactory uiFactory, IBattleTickService battleTickService, IBattleUiService battleUIService,
            IBattleProvider battleProvider)
        {
            _gameStateMachine = gameStateMachine;
            _battleObserver = battleObserver;
            _uiFactory = uiFactory;
            _battleTickService = battleTickService;
            _battleUiService = battleUIService;
            _battleProvider = battleProvider;
        }

        public void Enter()
        {
            _battle = _battleProvider.CurrentBattle;
            _battle.StartBattle();
            _battleTickService.IsPaused = false;
            _pauseResumeUi = _uiFactory.CreatePauseResumeUi();
            _pauseResumeUi.Show();
            _pauseResumeUi.OnPauseContinueButtonClicked += OnPauseContinueButtonClicked;

            _battleObserver.StartObserve(_battle);
            _battleObserver.OnWinnerDetermined += OnWinnerDeterminedEventHandler;
        }

        public void Exit()
        {
            _pauseResumeUi.OnPauseContinueButtonClicked -= OnPauseContinueButtonClicked;
            _battleObserver.OnWinnerDetermined -= OnWinnerDeterminedEventHandler;
            _pauseResumeUi.Hide();

        }

        private void OnWinnerDeterminedEventHandler(ISpaceShip winner)
        {
            _battle.StopBattle();
            _battleObserver.StopObserve();
            _battleUiService.BattleUi.HideBattleView();
            _battleTickService.IsPaused = true;

            _gameStateMachine.EnterState<ShowWinnerState>();
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
    }
}
