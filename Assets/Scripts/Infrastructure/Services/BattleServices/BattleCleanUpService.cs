using Assets.Scripts.Battles;
using Assets.Scripts.Battles.BattleRun;
using Assets.Scripts.Infrastructure.Destroyers;
using Assets.Scripts.Infrastructure.Services.Registries;
<<<<<<< HEAD
=======
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.SpaceShips;
using System.Collections.Generic;
>>>>>>> parent of 015454a (Revert "Refactor Battle to BattleRunner. Change BattleData implementation")
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

        public void CleanUpBattle(BattleRunner battleRunner)
        {
            _projectilesPoolService.ClearAll();

<<<<<<< HEAD
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
=======
            DestroyAndUnregisterGameObjects(battleRunner);
            _battleUIService.DestroyBattleUi();
        }

        private void DestroyAndUnregisterGameObjects(BattleRunner battleRunner)
        {
            foreach(var spaceShip in battleRunner.BattleData.AllyTeamMembers.ToArray())
            {
                RemoveAndDestroySpaceShipWeapons(spaceShip);
                battleRunner.RemoveSpaceShipFromAllyTeam(spaceShip);
                _spaceShipDestroyer.Destroy(spaceShip);
            }

            foreach (var spaceShip in battleRunner.BattleData.EnemyTeamMembers.ToArray())
            {
                RemoveAndDestroySpaceShipWeapons(spaceShip);
                battleRunner.RemoveSpaceShipFromEnemyTeam(spaceShip);
                _spaceShipDestroyer.Destroy(spaceShip);
            }

            foreach (var projectile in (_projectilesRegister.Projectiles.ToArray()))
                _projectileDestroyer.Destroy(projectile);
        }

        private void RemoveAndDestroySpaceShipWeapons(ISpaceShip spaceShip)
        {
            foreach (var weapon in spaceShip.Weapons.ToArray())
            {
                spaceShip.RemoveWeapon(weapon);
                _weaponDestroyer.Destroy(weapon);
            }
>>>>>>> parent of 015454a (Revert "Refactor Battle to BattleRunner. Change BattleData implementation")
        }
    }
}
