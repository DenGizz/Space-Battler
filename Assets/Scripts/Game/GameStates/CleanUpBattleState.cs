using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.StateMachines;

namespace Assets.Scripts.Game.GameStates
{
    public class CleanUpBattleState : IState
    {
        private readonly IBattleCleanUpService _battleCleanUpService;
        private readonly IBattleProvider _battleProvider;
        private readonly StateMachine _stateMachine;

        public CleanUpBattleState(StateMachine stateMachine, IBattleCleanUpService battleCleanUpService, IBattleProvider battleProvider)
        {
            _stateMachine = stateMachine;
            _battleCleanUpService = battleCleanUpService;
            _battleProvider = battleProvider;
        }

        public void Enter()
        {
            Battle battle = _battleProvider.CurrentBattle;
            _battleCleanUpService.CleanUpBattle(battle);
            _stateMachine.EnterState<LoadMainMenuSceneState>();
        }

        public void Exit()
        {

        }
    }
}
