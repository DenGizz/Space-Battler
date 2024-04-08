using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.SpaceShip;
using Assets.Scripts.StateMachines;

namespace Assets.Scripts.Game.GameStateMachine.GameStates
{
    public class BattleState : IState, IStateWithArtuments<Battle.Battle>
    {
        private readonly IBattleObserver _battleObserver;

        private readonly StateMachine _gameStateMachine;

        private Battle.Battle _battle;

        public BattleState(StateMachine gameStateMachine, IBattleObserver battleObserver)
        {
            _gameStateMachine = gameStateMachine;
            _battleObserver = battleObserver;
        }

        public void Enter()
        {

        }

        public void Enter(Battle.Battle args)
        {
            _battle = args;
            StartBattle();
            _battleObserver.StartObserve(_battle);
            _battleObserver.OnWinnerDetermined += OnWinnerDeterminedEventHandler;
        }

        public void Exit()
        {
            _battleObserver.OnWinnerDetermined -= OnWinnerDeterminedEventHandler;
        }

        private void OnWinnerDeterminedEventHandler(ISpaceShip winner)
        {
            StopBattle();
            _gameStateMachine.EnterState<CleanUpBattleState,Battle.Battle>(_battle);
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
    }
}
