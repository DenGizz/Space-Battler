using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.StateMachines;

namespace Assets.Scripts.Game.GameStateMachine.GameStates
{
    public class CleanUpBattleState : IState, IStateWithArtuments<Battle.Battle>
    {
        private readonly IBattleCleanUpServce _battleCleanUpServce;
        private readonly StateMachine _stateMachine;

        public CleanUpBattleState(StateMachine stateMachine, IBattleCleanUpServce battleCleanUpServce)
        {
            _stateMachine = stateMachine;
            _battleCleanUpServce = battleCleanUpServce;
        }

        public void Enter()
        {

        }

        public void Enter(Battle.Battle args)
        {
            _battleCleanUpServce.CleanUpBattle(args);
            _stateMachine.EnterState<LoadMainMenuSceneState>();
        }

        public void Exit()
        {

        }
    }
}
