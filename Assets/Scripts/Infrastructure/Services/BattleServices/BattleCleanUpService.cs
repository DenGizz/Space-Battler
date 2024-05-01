using Assets.Scripts.Battles;
using Assets.Scripts.Battles.BattleRun;
using Assets.Scripts.Infrastructure.Destroyers;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.SpaceShips;
using System.Collections.Generic;
using System.Linq;
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
        }
    }
}
