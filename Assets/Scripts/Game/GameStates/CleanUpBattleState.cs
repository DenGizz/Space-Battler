using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.StateMachines;

namespace Assets.Scripts.Game.GameStates
{
    public class CleanUpBattleState : IState, IStateWithArtuments<Battle>
    {
        private readonly IBattleCleanUpService _battleCleanUpService;
        private readonly StateMachine _stateMachine;

        public CleanUpBattleState(StateMachine stateMachine, IBattleCleanUpService battleCleanUpService)
        {
            _stateMachine = stateMachine;
            _battleCleanUpService = battleCleanUpService;
        }

        public void Enter()
        {

        }

        public void Enter(Battle args)
        {
            _battleCleanUpService.CleanUpBattle(args);
            _stateMachine.EnterState<LoadMainMenuSceneState>();
        }

        public void Exit()
        {

        }
    }
}
