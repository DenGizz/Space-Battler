using Assets.Scripts.Battles;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Gameplay.Factories;
using Assets.Scripts.Infrastructure.SandboxMode.Factories;
using Assets.Scripts.Infrastructure.SandboxMode.Services;
using Assets.Scripts.Infrastructure.Ui.Providers;
using Assets.Scripts.StateMachines;
using Assets.Scripts.UI.UiScreens.SandboxModeUiScreens;
using UnityEngine;

namespace Assets.Scripts.Game.GameStates.SandboxLoopStates
{
    public class CreateBattleState : IState
    {
        private readonly IBattleSetupProvider _battleSetupProvider;
        private readonly IBattleSetupsShrinkService _battleSetupsShrinkService;
        private readonly IBattleRunnerProvider _battleRunnerProvider;
        private readonly IBattleRunnerFactory _battleRunnerFactory;
        private readonly IUisProvider _uisProvider;

        private readonly StateMachine _stateMachine;

        public CreateBattleState(StateMachine stateMachine,
            IBattleSetupProvider battleSetupProvider, IBattleSetupsShrinkService battleSetupsShrinkService, 
            IBattleRunnerProvider battleRunnerProvider, IBattleRunnerFactory battleRunnerFactory, IUisProvider uisProvider)
        {
            _stateMachine = stateMachine;
            _battleSetupProvider = battleSetupProvider;
            _battleSetupsShrinkService = battleSetupsShrinkService;
            _battleRunnerProvider = battleRunnerProvider;
            _battleRunnerFactory = battleRunnerFactory;
            _uisProvider = uisProvider;
        }

        public void Enter()
        {
            BattleSetup battleSetup = _battleSetupProvider.BattleSetup;
            BattleRunner battleRunner = _battleSetupsShrinkService.UnShrinkBattleSetup(battleSetup);
            _battleRunnerProvider.CurrentBattleRunner = battleRunner;
            _uisProvider.SandboxModeUi
                .GoToScreen<SandboxBattleViewUiScreen>()
                .SetBattleData(battleRunner.BattleData);

            _stateMachine.EnterState<BattleState>();
        }


        public void Exit()
        {

        }
    }
}
