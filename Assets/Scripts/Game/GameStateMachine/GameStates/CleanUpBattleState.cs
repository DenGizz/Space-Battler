using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.StateMachine;

namespace Assets.Scripts.Game.GameStateMachine.GameStates
{
    public class CleanUpBattleState : IState, IStateWithArtuments<Battle.Battle>
    {
        private readonly IBattleCleanUpServce _battleCleanUpServce;
        private readonly GameStateMachine _gameStateMachine;

        public CleanUpBattleState(GameStateMachine gameStateMachine, IBattleCleanUpServce battleCleanUpServce)
        {
            _gameStateMachine = gameStateMachine;
            _battleCleanUpServce = battleCleanUpServce;
        }

        public void Enter()
        {

        }

        public void Enter(Battle.Battle args)
        {
            _battleCleanUpServce.CleanUpBattle(args);
            _gameStateMachine.EnterState<LoadMainMenuSceneState>();
        }

        public void Exit()
        {

        }
    }
}
