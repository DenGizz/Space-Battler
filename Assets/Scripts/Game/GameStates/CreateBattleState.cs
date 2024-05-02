using Assets.Scripts.Battles;
using Assets.Scripts.Battles.BattleRun;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.Infrastructure.Services.BattleServices;
using Assets.Scripts.StateMachines;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game.GameStates
{
    public class CreateBattleState : IState
    {
        private readonly IBattleUiService _battleUIService;
        private readonly IBattleSetupProvider _battleSetupProvider;
        private readonly IShrinkService _shrinkService;
        private readonly IBattleRunnerProvider _battleRunnerProvider;
        private readonly IInstantiator _instantiator;

        private readonly StateMachine _stateMachine;

        public CreateBattleState(StateMachine stateMachine,IBattleUiService battleUIService,
            IBattleSetupProvider battleSetupProvider, IShrinkService shrinkService, 
            IBattleRunnerProvider battleRunnerProvider, IInstantiator instantiator)
        {
            _stateMachine = stateMachine;
            _battleUIService = battleUIService;
            _battleSetupProvider = battleSetupProvider;
            _shrinkService = shrinkService;
            _battleRunnerProvider = battleRunnerProvider;
            _instantiator = instantiator;
        }

        public void Enter()
        {
            BattleSetup battleSetup = _battleSetupProvider.BattleSetup;

            (ISpaceShip player, ISpaceShip enemy) = CreateSpaceShipsAndWeapons(battleSetup);;
            BattleData battleData = new BattleData();
            BattleRunner battleRunner = _instantiator.Instantiate<BattleRunner>(new[]{ battleData}); //TODO: This should do factory

            battleRunner.AddSpaceShipToAllyTeam(player);
            battleRunner.AddSpaceShipToEnemyTeam(enemy);

            _battleRunnerProvider.CurrentBattleRunner = battleRunner;

            _battleUIService.CreateBattleUi();
            _battleUIService.SetBattle(battleRunner.BattleData);

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
