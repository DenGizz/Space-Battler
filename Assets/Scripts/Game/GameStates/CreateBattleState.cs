using System.Collections.Generic;
using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.Infrastructure.Factories.UI_Factories;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.SpaceShips;
using Assets.Scripts.SpaceShips.SpaceShipConfigs;
using Assets.Scripts.StateMachines;
using Assets.Scripts.Weapons;
using Assets.Scripts.Weapons.WeaponConfigs;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game.GameStates
{
    public class CreateBattleState : IState
    {
        private readonly IBattleUiService _battleUIService;
        private readonly IBattleFactory _battleFactory;
        private readonly IBattleSetupProvider _battleSetupProvider;
        private readonly ISpaceShipFromSetupFactory _spaceShipFromSetupFactory;

        private readonly StateMachine _stateMachine;

        public CreateBattleState(StateMachine stateMachine,IBattleUiService battleUIService, IBattleFactory battleFactory,
            IBattleSetupProvider battleSetupProvider, ISpaceShipFromSetupFactory spaceShipFromSetupFactory)
        {
            _stateMachine = stateMachine;
            _battleUIService = battleUIService;
            _battleFactory = battleFactory;
            _battleSetupProvider = battleSetupProvider;
            _spaceShipFromSetupFactory = spaceShipFromSetupFactory;
        }

        public void Enter()
        {
            BattleSetup battleSetup = _battleSetupProvider.BattleSetup;

            (ISpaceShip player, ISpaceShip enemy) = CreateSpaceShipsAndWeapons(battleSetup);

            Battle battle = _battleFactory.CreateBattle(player, enemy);

            _battleUIService.CreateBattleUi();
            _battleUIService.SetBattle(battle);

            _stateMachine.EnterState<BattleState,Battle>(battle);
        }


        public void Exit()
        {

        }

        private (ISpaceShip player, ISpaceShip enemy) CreateSpaceShipsAndWeapons(BattleSetup setup)
        {
            //Instantiate units
            Vector3 playerSpaceShipPosition = Vector3.zero - Vector3.right * 7;
            Vector3 enemySpaceShipPosition = Vector3.zero + Vector3.right * 7;

            float playerSpaceShipZRotation = -90;
            float enemySpaceShipZRotation = 90;

            ISpaceShip player = _spaceShipFromSetupFactory.CreateSpaceShipFromSetup(setup.PlayerSetup, playerSpaceShipPosition, playerSpaceShipZRotation);
            ISpaceShip enemy = _spaceShipFromSetupFactory.CreateSpaceShipFromSetup(setup.EnemySetup, enemySpaceShipPosition, enemySpaceShipZRotation);


            return (player, enemy);
        }
    }
}
