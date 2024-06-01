using System.Linq;
using Assets.Scripts.Battles.BattleRun;
using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Gameplay.GameObjectDestroyers;
using Assets.Scripts.Infrastructure.Gameplay.Registries;
using Assets.Scripts.Infrastructure.Gameplay.Services;
using Zenject;

namespace Assets.Scripts.Infrastructure.SandboxMode.Services
{
    public class BattleCleanUpService : IBattleCleanUpService
    {
        private readonly IProjectilesRegister _projectilesRegister;
        private readonly IProjectileDestroyer _projectileDestroyer;
        private readonly IWeaponDestroyer _weaponDestroyer;
        private readonly ISpaceShipDestroyer _spaceShipDestroyer;
        private readonly IProjectilesPoolService _projectilesPoolService;

        [Inject]
        public BattleCleanUpService(IProjectilesRegister projectilesRegister, IProjectileDestroyer projectileDestroyer, IWeaponDestroyer weaponDestroyer, ISpaceShipDestroyer spaceShipDestroyer, IProjectilesPoolService projectilesPoolService)
        {
            _projectilesRegister = projectilesRegister;
            _projectileDestroyer = projectileDestroyer;
            _weaponDestroyer = weaponDestroyer;
            _spaceShipDestroyer = spaceShipDestroyer;
            _projectilesPoolService = projectilesPoolService;
        }

        public void CleanUpBattle(BattleRunner battleRunner)
        {
            _projectilesPoolService.ClearAll();
            DestroyAliveBattleUnits(battleRunner);
        }

        private void DestroyAliveBattleUnits(BattleRunner battleRunner)
        {
            DestroyAndUnregisterGameObjects(battleRunner);
        }

        private void DestroyAndUnregisterGameObjects(BattleRunner battleRunner)
        {
            foreach(var spaceShip in battleRunner.BattleData.AllyTeam.Members.ToArray())
            {
                RemoveAndDestroySpaceShipWeapons(spaceShip);
                battleRunner.RemoveSpaceShipFromAllyTeam(spaceShip);
                _spaceShipDestroyer.Destroy(spaceShip);
            }

            foreach (var spaceShip in battleRunner.BattleData.EnemyTeam.Members.ToArray())
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
            foreach (var weapon in spaceShip.Data.Weapons.ToArray())
            {
                spaceShip.RemoveWeapon(weapon);
                _weaponDestroyer.Destroy(weapon);
            }
        }
    }
}
