using Assets.Scripts.AI.UnitsAI;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.SpaceShip;
using Assets.Scripts.StateMachine;

namespace Assets.Scripts.Infrastructure.Game.GameStateMachine
{
    public class BattleState : IState
    {
        private readonly IBattleObserver _battleObserver;
        private readonly IBattleDataProvider _battleDataProvider;
        private readonly IBattleController _battleController;


        private readonly GameStateMachine GameStateMachine;

        public BattleState(GameStateMachine gameStateMachine, IBattleObserver battleObserver, IBattleDataProvider battleDataProvider, IBattleController battleController)
        {
            GameStateMachine = gameStateMachine;
            _battleObserver = battleObserver;
            _battleDataProvider = battleDataProvider;
            _battleController = battleController;
        }

        public void Enter()
        {
            StartBattle();
            _battleObserver.OnWinnerDetermined += OnWinerDeterminedEventHandler;
        }

        public void Exit()
        {
            _battleObserver.OnWinnerDetermined -= OnWinerDeterminedEventHandler;
        }

        private void OnWinerDeterminedEventHandler(ISpaceShip winner)
        {
            StopBattle();
            GameStateMachine.EnterState<CleanUpBattleState>();
        }

        private void StartBattle()
        {
            _battleObserver.StartObserve(_battleDataProvider.CurrentBattleData);
            _battleController.StartBattle(_battleDataProvider.CurrentBattleData);
        }

        private void StopBattle()
        {
            _battleController.StopBattle(_battleDataProvider.CurrentBattleData);
        }

        private void ResumeBattle()
        {
            _battleController.ResumeBattle(_battleDataProvider.CurrentBattleData);
        }
    }
}
