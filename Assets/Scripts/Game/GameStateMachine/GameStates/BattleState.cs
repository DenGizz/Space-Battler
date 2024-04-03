using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.SpaceShip;
using Assets.Scripts.StateMachine;

namespace Assets.Scripts.Infrastructure.Game.GameStateMachine.GameStates
{
    public class BattleState : IState
    {
        private readonly IBattleObserver _battleObserver;
        private readonly IBattleProvider _battleDataProvider;


        private readonly GameStateMachine GameStateMachine;

        public BattleState(GameStateMachine gameStateMachine, IBattleObserver battleObserver, IBattleProvider battleDataProvider)
        {
            GameStateMachine = gameStateMachine;
            _battleObserver = battleObserver;
            _battleDataProvider = battleDataProvider;
        }

        public void Enter()
        {
            StartBattle();
            _battleObserver.StartObserve(_battleDataProvider.CurrentBattle);
            _battleObserver.OnWinnerDetermined += OnWinnerDeterminedEventHandler;
        }

        public void Exit()
        {
            _battleObserver.OnWinnerDetermined -= OnWinnerDeterminedEventHandler;
        }

        private void OnWinnerDeterminedEventHandler(ISpaceShip winner)
        {
            StopBattle();
            GameStateMachine.EnterState<CleanUpBattleState>();
        }

        private void StartBattle()
        {
            _battleDataProvider.CurrentBattle.StartBattle();
        }

        private void StopBattle()
        {
            _battleDataProvider.CurrentBattle.StopBattle();
        }

        private void ResumeBattle()
        {
            _battleDataProvider.CurrentBattle.ResumeBattle();
        }
    }
}
