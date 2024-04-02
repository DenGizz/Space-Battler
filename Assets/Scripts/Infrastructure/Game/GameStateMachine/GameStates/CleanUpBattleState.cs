using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Game.GameStateMachine
{
    public class CleanUpBattleState : IState
    {
        private readonly IBattleCleanUpServce _battleCleanUpServce;
        private readonly IBattleDataProvider _battleDataProvider;
        private readonly GameStateMachine _gameStateMachine;

        public CleanUpBattleState(GameStateMachine gameStateMachine, IBattleDataProvider battleDataProvider, IBattleCleanUpServce battleCleanUpServce)
        {
            _gameStateMachine = gameStateMachine;
            _battleDataProvider = battleDataProvider;
            _battleCleanUpServce = battleCleanUpServce;
        }

        public void Enter()
        {
            _battleCleanUpServce.CleanUpBattle(_battleDataProvider.CurrentBattleData);
        }

        public void Exit()
        {

        }
    }
}
