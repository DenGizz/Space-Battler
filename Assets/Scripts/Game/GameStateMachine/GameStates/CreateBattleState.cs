using System;
using System.Collections.Generic;
using Assets.Scripts.Battle;
using Assets.Scripts.Infrastructure.Factories;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.SpaceShip;
using Assets.Scripts.SpaceShip.SpaceShipConfigs;
using Assets.Scripts.StateMachine;
using Assets.Scripts.Weapons.WeaponConfigs;
using UnityEngine;

namespace Assets.Scripts.Game.GameStateMachine.GameStates
{
    public class CreateBattleState : IState
    {
        private readonly ISpaceShipFactory _spaceShipFactory;
        private readonly IBattleUIService _battleUIService;
        private readonly IBattleFactory _battleFactory;
        private readonly IWeaponFactory _weaponFactory;
        private readonly IBattleSetupProvider _battleSetupProvider;

        private readonly GameStateMachine GameStateMachine;

        public CreateBattleState(GameStateMachine gameStateMachine, ISpaceShipFactory spaceShipFactory , IBattleUIService battleUIService, 
            IBattleFactory battleFactory, IWeaponFactory weaponFactory, IBattleSetupProvider battleSetupProvider)
        {
            GameStateMachine = gameStateMachine;
            _spaceShipFactory = spaceShipFactory;
            _battleUIService = battleUIService;
            _battleFactory = battleFactory;
            _weaponFactory = weaponFactory;
            _battleSetupProvider = battleSetupProvider;
        }

        public void Enter()
        {
            CreateBattle(_battleSetupProvider.BattleSetup);
            GameStateMachine.EnterState<BattleState>();
        }


        public void Exit()
        {

        }

        private void CreateBattle(BattleSetup setup)
        {
            //Instantiate units
            Vector3 playerSpaceShipPosition = Vector3.zero - Vector3.right * 7;
            Vector3 enemySpaceShipPosition = Vector3.zero + Vector3.right * 7;

            float playerSpaceShipZRotation = -90;
            float enemySpaceShipZRotation = 90;

            Color playerSpaceShipColor = Color.green;
            Color enemySpaceShipColor = Color.red;

            SpaceShipType playerSpaceShipType = setup.PlayerSetup.SpaceShipType.Value;
            SpaceShipType enemySpaceShipType = setup.EnemySetup.SpaceShipType.Value;

            IEnumerable<WeaponType> playerWeaponTypes = setup.PlayerSetup.WeaponTypes;
            IEnumerable<WeaponType> enemyWeaponTypes = setup.EnemySetup.WeaponTypes;

            ISpaceShip player = _spaceShipFactory.CreateSpaceShip(playerSpaceShipType, playerSpaceShipPosition, playerSpaceShipZRotation, playerSpaceShipColor);
            ISpaceShip enemy = _spaceShipFactory.CreateSpaceShip(enemySpaceShipType, enemySpaceShipPosition, enemySpaceShipZRotation, enemySpaceShipColor);

            foreach (var weaponType in playerWeaponTypes)
            {
                IWeapon weapon = _weaponFactory.CreateWeapon(weaponType, playerSpaceShipPosition + UnityEngine.Random.insideUnitSphere, playerSpaceShipZRotation);
                player.AddWeapon(weapon);
            }

            foreach (var weaponType in enemyWeaponTypes)
            {
                IWeapon weapon = _weaponFactory.CreateWeapon(weaponType, enemySpaceShipPosition + UnityEngine.Random.insideUnitSphere, enemySpaceShipZRotation);
                enemy.AddWeapon(weapon);
            }


            Battle.Battle battle = _battleFactory.CreateBattle(player, enemy);

            _battleUIService.CreateBattleUI();
            _battleUIService.SetBattle(battle);
        }
    }
}
