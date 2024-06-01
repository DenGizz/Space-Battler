using Assets.Scripts.Battles;
using Assets.Scripts.Battles.BattleRun;
using Assets.Scripts.Game.GameStates.SandboxLoopStates;
using Assets.Scripts.Infrastructure.SandboxMode.Services;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.StateMachines;

namespace Assets.Scripts.Game.GameStates
{
    public class CleanUpBattleState : IState
    {
        private readonly IBattleCleanUpService _battleCleanUpService;
        private readonly IBattleRunnerProvider _battleRunnerProvider;
        private readonly StateMachine _stateMachine;

        public CleanUpBattleState(StateMachine stateMachine, IBattleCleanUpService battleCleanUpService, IBattleRunnerProvider battleRunnerProvider)
        {
            _stateMachine = stateMachine;
            _battleCleanUpService = battleCleanUpService;
            _battleRunnerProvider = battleRunnerProvider;
        }

        public void Enter()
        {
            BattleRunner battleRunner = _battleRunnerProvider.CurrentBattleRunner;
            _battleCleanUpService.CleanUpBattle(battleRunner);
            _stateMachine.EnterState<EditBattleSetupState>();
        }

        public void Exit()
        {

        }
    }
}
