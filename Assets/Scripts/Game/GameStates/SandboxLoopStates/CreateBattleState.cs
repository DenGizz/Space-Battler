using Assets.Scripts.Battles;
using Assets.Scripts.Battles.BattleRun;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Gameplay.Factories;
using Assets.Scripts.Infrastructure.SandboxMode.Factories;
using Assets.Scripts.Infrastructure.SandboxMode.Services;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.Infrastructure.Ui.Providers;
using Assets.Scripts.StateMachines;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game.GameStates
{
    public class CreateBattleState : IState
    {
        private readonly IBattleSetupProvider _battleSetupProvider;
        private readonly IShrinkService _shrinkService;
        private readonly IBattleRunnerProvider _battleRunnerProvider;
        private readonly IBattleRunnerFactory _battleRunnerFactory;
        private readonly IUisProvider _uisProvider;

        private readonly StateMachine _stateMachine;

        public CreateBattleState(StateMachine stateMachine,
            IBattleSetupProvider battleSetupProvider, IShrinkService shrinkService, 
            IBattleRunnerProvider battleRunnerProvider, IBattleRunnerFactory battleRunnerFactory, IUisProvider uisProvider)
        {
            _stateMachine = stateMachine;
            _battleSetupProvider = battleSetupProvider;
            _shrinkService = shrinkService;
            _battleRunnerProvider = battleRunnerProvider;
            _battleRunnerFactory = battleRunnerFactory;
            _uisProvider = uisProvider;
        }

        public void Enter()
        {
            BattleSetup battleSetup = _battleSetupProvider.BattleSetup;

            (ISpaceShip player, ISpaceShip enemy) = CreateSpaceShipsAndWeapons(battleSetup);;
            BattleData battleData = new BattleData();
            BattleRunner battleRunner = _battleRunnerFactory.CreateBattleRunner(battleData);

            battleRunner.AddSpaceShipToAllyTeam(player);
            battleRunner.AddSpaceShipToEnemyTeam(enemy);

            _battleRunnerProvider.CurrentBattleRunner = battleRunner;

            var battleScreen = _uisProvider.SandboxModeUi.GoToScreen<SandboxBattleViewUiScreen>();
            battleScreen.SetBattleData(battleData);

            _stateMachine.EnterState<BattleState>();
        }


        public void Exit()
        {

        }

        private (ISpaceShip player, ISpaceShip enemy) CreateSpaceShipsAndWeapons(BattleSetup setup)
        {
            ISpaceShip player = _shrinkService.UnShrinkSpaceShip(setup.PlayerSetup, Vector3.zero, 0);
            ISpaceShip enemy = _shrinkService.UnShrinkSpaceShip(setup.EnemySetup, Vector3.zero, 0);


            return (player, enemy);
        }
    }
}
