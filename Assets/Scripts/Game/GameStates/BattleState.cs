using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.SpaceShips;
using Assets.Scripts.StateMachines;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.GameStates
{
    public class BattleState : IState, IStateWithArtuments<Battle>
    {
        private readonly IBattleObserver _battleObserver;
        private readonly IUIFactory _uIFactory;
        private readonly StateMachine _gameStateMachine;
        private readonly IBattleTickService _battleTickService;
        private readonly IBattleUIService _battleUIService;

        private Battle _battle;

        public BattleState(StateMachine gameStateMachine, IBattleObserver battleObserver, IUIFactory uIFactory, IBattleTickService battleTickService, IBattleUIService battleUIService)
        {
            _gameStateMachine = gameStateMachine;
            _battleObserver = battleObserver;
            _uIFactory = uIFactory;
            _battleTickService = battleTickService;
            _battleUIService = battleUIService;
        }

        public void Enter()
        {

        }

        public void Enter(Battle args)
        {
            _battle = args;
            _battle.StartBattle();

            PauseResumeUI pauseMenu = _uIFactory.CreatePauseResumeUi();
            pauseMenu.OnPauseContinueButtonClicked += OnPauseContinueButtonClicked;

            _battleObserver.StartObserve(_battle);
            _battleObserver.OnWinnerDetermined += OnWinnerDeterminedEventHandler;
        }

        public void Exit()
        {
            _battleObserver.OnWinnerDetermined -= OnWinnerDeterminedEventHandler;
        }

        private void OnWinnerDeterminedEventHandler(ISpaceShip winner)
        {
            _battle.StopBattle();
            _battleUIService.BattleUI.HideBattleView();
            _battleUIService.BattleUI.ShowWinner(winner, _battle.BattleData.PlayerSpaceShip == winner);

            System.Threading.Thread.Sleep(3000);
            _gameStateMachine.EnterState<CleanUpBattleState, Battle>(_battle);
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
