using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.SpaceShips;
using Assets.Scripts.StateMachines;

namespace Assets.Scripts.Game.GameStates
{
    public class BattleState : IState, IStateWithArtuments<Battle>
    {
        private readonly IBattleObserver _battleObserver;
        private readonly IUIFactory _uIFactory;
        private readonly StateMachine _gameStateMachine;

        private Battle _battle;

        public BattleState(StateMachine gameStateMachine, IBattleObserver battleObserver, IUIFactory uIFactory)
        {
            _gameStateMachine = gameStateMachine;
            _battleObserver = battleObserver;
            _uIFactory = uIFactory;
        }

        public void Enter()
        {

        }

        public void Enter(Battle args)
        {
            _battle = args;
            StartBattle();
            _battleObserver.StartObserve(_battle);
            _battleObserver.OnWinnerDetermined += OnWinnerDeterminedEventHandler;

            PauseResumeUI pauseMenu = _uIFactory.CreatePauseResumeUi();

            pauseMenu.OnPauseContinueButtonClicked += OnPauseContinueButtonClicked;
        }

        public void Exit()
        {
            _battleObserver.OnWinnerDetermined -= OnWinnerDeterminedEventHandler;
        }

        private void OnWinnerDeterminedEventHandler(ISpaceShip winner)
        {
            StopBattle();
            _gameStateMachine.EnterState<CleanUpBattleState,Battle>(_battle);
        }

        private void StartBattle()
        {
            _battle.StartBattle();
        }

        private void StopBattle()
        {
            _battle.StopBattle();
        }

        private void ResumeBattle()
        {
            _battle.ResumeBattle();
        }


        private void OnPauseContinueButtonClicked()
        {
            if (_battle.IsBattleActive)
                StopBattle();
            else
                ResumeBattle();
        }
    }
}
