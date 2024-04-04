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
        private readonly IStaticDataService _staticDataService;
        private readonly IWeaponFactory _weaponFactory;

        private readonly GameStateMachine GameStateMachine;

        public CreateBattleState(GameStateMachine gameStateMachine, ISpaceShipFactory spaceShipFactory , IBattleUIService battleUIService, 
            IBattleFactory battleFactory, IStaticDataService staticDataService, IWeaponFactory weaponFactory)
        {
            GameStateMachine = gameStateMachine;
            _spaceShipFactory = spaceShipFactory;
            _battleUIService = battleUIService;
            _battleFactory = battleFactory;
            _staticDataService = staticDataService;
            _weaponFactory = weaponFactory;
        }

        public void Enter()
        {
            CreateBattle();
            GameStateMachine.EnterState<BattleState>();
        }

        public void Exit()
        {

        }

        private void CreateBattle()
        {
            //Instantiate units
            Vector3 playerSpaceShipPosition = Vector3.zero - Vector3.right * 7;
            Vector3 enemySpaceShipPosition = Vector3.zero + Vector3.right * 7;

            float playerSpaceShipZRotation = -90;
            float enemySpaceShipZRotation = 90;

            Color playerSpaceShipColor = Color.green;
            Color enemySpaceShipColor = Color.red;

            IWeapon playerRocketLauncher = _weaponFactory.CreateWeapon(WeaponType.RocketLauncher, playerSpaceShipPosition + Vector3.up, playerSpaceShipZRotation);
            IWeapon playerHeavyMachineGun = _weaponFactory.CreateWeapon(WeaponType.HeavyMachineGun, playerSpaceShipPosition + Vector3.down, playerSpaceShipZRotation);

            IWeapon enemyLiteBlaster = _weaponFactory.CreateWeapon(WeaponType.LiteBlaster, enemySpaceShipPosition + Vector3.up, enemySpaceShipZRotation);
            IWeapon enemyGrenadeLauncher = _weaponFactory.CreateWeapon(WeaponType.GrenadeLauncher, enemySpaceShipPosition + Vector3.down, enemySpaceShipZRotation);

            //TODO: Move to SpaceShipFactory
            SpaceShipConfig playerSpaceShipConfig = _staticDataService.GetSpaceShipConfiguration(SpaceShipType.HeavyDefender);
            SpaceShipConfig enemySpaceShipConfig = _staticDataService.GetSpaceShipConfiguration(SpaceShipType.LiteAttacker);

            ISpaceShip player = _spaceShipFactory.CreateSpaceShip(playerSpaceShipConfig, playerSpaceShipPosition, playerSpaceShipZRotation, playerSpaceShipColor);
            ISpaceShip enemy = _spaceShipFactory.CreateSpaceShip(enemySpaceShipConfig, enemySpaceShipPosition, enemySpaceShipZRotation, enemySpaceShipColor);

            player.AddWeapon(playerRocketLauncher);
            player.AddWeapon(playerHeavyMachineGun);
            enemy.AddWeapon(enemyLiteBlaster);
            enemy.AddWeapon(enemyGrenadeLauncher);

            Battle.Battle battle = _battleFactory.CreateBattle(player, enemy);

            _battleUIService.CreateBattleUI();
            _battleUIService.SetBattle(battle);
        }
    }
}
