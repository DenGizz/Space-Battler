using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Destroyers;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.ScriptableObjects;
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

        [Inject]
        public BattleCleanUpService(IBattleUiService battleUIService, 
            IProjectilesRegister projectilesRegister, IProjectileDestroyer projectileDestroyer, IWeaponDestroyer weaponDestroyer, ISpaceShipDestroyer spaceShipDestroyer)
        {
            _battleUIService = battleUIService;
            _projectilesRegister = projectilesRegister;
            _projectileDestroyer = projectileDestroyer;
            _weaponDestroyer = weaponDestroyer;
            _spaceShipDestroyer = spaceShipDestroyer;
        }

        public void CleanUpBattle(Battle battle)
        {
            BattleData battleData = battle.BattleData;

            DestroyAndUnregisterGameObjects(battleData);
            _battleUIService.DestroyBattleUi();
        }

        private void DestroyAndUnregisterGameObjects(BattleData battleData)
        {
            foreach (var weapon in battleData.PlayerSpaceShip.Weapons.ToArray())
            {
                battleData.PlayerSpaceShip.RemoveWeapon(weapon);
                _weaponDestroyer.Destroy(weapon);
            }

            foreach (var weapon in battleData.EnemySpaceShip.Weapons.ToArray())
            {
                battleData.EnemySpaceShip.RemoveWeapon(weapon);
                _weaponDestroyer.Destroy(weapon);
            }

            _spaceShipDestroyer.Destroy(battleData.PlayerSpaceShip);
            _spaceShipDestroyer.Destroy(battleData.EnemySpaceShip);

            var sss = new List<ProjectileBehaviour>(_projectilesRegister.Projectiles);

            foreach (var projectile in sss)
            {
                _projectileDestroyer.Destroy(projectile);
            }
        }
    }
}
