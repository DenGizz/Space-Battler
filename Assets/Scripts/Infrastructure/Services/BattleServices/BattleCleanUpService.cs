using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Destroyers;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.ScriptableObjects;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Assets.Scripts.Entities.SpaceShips;
using Zenject;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public class BattleCleanUpService : IBattleCleanUpService
    {
        private readonly IBattleUiService _battleUIService;
        private readonly IProjectilesRegister _projectilesRegister;
        private readonly IProjectileDestroyer _projectileDestroyer;
        private readonly IWeaponDestroyer _weaponDestroyer;
        private readonly ISpaceShipDestroyer _spaceShipDestroyer;
        private readonly IProjectilesPoolService _projectilesPoolService;

        [Inject]
        public BattleCleanUpService(IBattleUiService battleUIService, 
            IProjectilesRegister projectilesRegister, IProjectileDestroyer projectileDestroyer, IWeaponDestroyer weaponDestroyer, ISpaceShipDestroyer spaceShipDestroyer, IProjectilesPoolService projectilesPoolService)
        {
            _battleUIService = battleUIService;
            _projectilesRegister = projectilesRegister;
            _projectileDestroyer = projectileDestroyer;
            _weaponDestroyer = weaponDestroyer;
            _spaceShipDestroyer = spaceShipDestroyer;
            _projectilesPoolService = projectilesPoolService;
        }

        public void CleanUpBattle(Battle battle)
        {
            BattleData battleData = battle.BattleData;

            _projectilesPoolService.ClearAll();

            DestroyAliveBattleUnits(battleData);
            _battleUIService.DestroyBattleUi();
        }

        private void DestroyAliveBattleUnits(BattleData battleData)
        {
            ISpaceShip playerSpaceShip = battleData.PlayerSpaceShip;
            ISpaceShip enemySpaceShip = battleData.EnemySpaceShip;

            if (playerSpaceShip != null)
            {
                foreach (var weapon in playerSpaceShip.Data.Weapons.ToArray())
                {
                    playerSpaceShip.RemoveWeapon(weapon);
                    _weaponDestroyer.Destroy(weapon);
                }

                _spaceShipDestroyer.Destroy(playerSpaceShip);
            }

            if(enemySpaceShip != null)
            {
                foreach (var weapon in enemySpaceShip.Data.Weapons.ToArray())
                {
                    enemySpaceShip.RemoveWeapon(weapon);
                    _weaponDestroyer.Destroy(weapon);
                }

                _spaceShipDestroyer.Destroy(enemySpaceShip);
            }

            foreach (var projectile in _projectilesRegister.Projectiles.ToArray())
                _projectileDestroyer.Destroy(projectile);
        }
    }
}
