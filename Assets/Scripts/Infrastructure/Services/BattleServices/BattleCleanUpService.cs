using Assets.Scripts.Battles;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using Assets.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public class BattleCleanUpService : IBattleCleanUpService
    {
        private readonly IGameObjectRegistry _gameObjectRegistry;
        private readonly ICombatAiRegistry _combatAIRegistry;
        private readonly IBattleUiService _battleUIService;
        private readonly IProjectilesRegister _projectilesRegister;
        private readonly IBattleTickService _battleTickService;
        private readonly IProjectileAutoDestroyService _projectileAutoDestroyService;

        [Inject]
        public BattleCleanUpService(IGameObjectRegistry gameObjectRegistry, ICombatAiRegistry combatAIRegistry, IBattleUiService battleUIService, IProjectilesRegister projectilesRegister, IBattleTickService battleTickService, IProjectileAutoDestroyService projectileAutoDestroyService)
        {
            _gameObjectRegistry = gameObjectRegistry;
            _combatAIRegistry = combatAIRegistry;
            _battleUIService = battleUIService;
            _projectilesRegister = projectilesRegister;
            _battleTickService = battleTickService;
            _projectileAutoDestroyService = projectileAutoDestroyService;
        }

        public void CleanUpBattle(Battle battle)
        {
            BattleData battleData = battle.BattleData;

            DestroyAndUnregisterGameObjects(battleData);

            _combatAIRegistry.UnRegisterAi(battleData.PlayerSpaceShip);
            _combatAIRegistry.UnRegisterAi(battleData.EnemySpaceShip);
            _battleUIService.DestroyBattleUi();
        }

        private void DestroyAndUnregisterGameObjects(BattleData battleData)
        {
            foreach (var weapon in battleData.PlayerSpaceShip.Weapons)
            {
                GameObject weaponGameObject = _gameObjectRegistry.GetWeaponGameObject(weapon);
                GameObject.Destroy(weaponGameObject);
                _gameObjectRegistry.UnRegisterGameObject(weaponGameObject);
            }

            foreach (var weapon in battleData.EnemySpaceShip.Weapons)
            {
                GameObject weaponGameObject = _gameObjectRegistry.GetWeaponGameObject(weapon);
                GameObject.Destroy(weaponGameObject);
                _gameObjectRegistry.UnRegisterGameObject(weaponGameObject);
            }

            GameObject playerSpaceChipGameObject = _gameObjectRegistry.GetSpaceShipGameObject(battleData.PlayerSpaceShip);
            GameObject enemySpaceChipGameObject = _gameObjectRegistry.GetSpaceShipGameObject(battleData.EnemySpaceShip);

            GameObject.Destroy(playerSpaceChipGameObject);
            GameObject.Destroy(enemySpaceChipGameObject);

            _gameObjectRegistry.UnRegisterGameObject(playerSpaceChipGameObject);
            _gameObjectRegistry.UnRegisterGameObject(enemySpaceChipGameObject);

            _gameObjectRegistry.UnRegisterAllProjectiles();

            var sss = new List<ProjectileBehaviour>(_projectilesRegister.Projectiles);

            foreach (var projectile in sss)
            {
                _projectileAutoDestroyService.UntrackProjectile(projectile);
                _projectilesRegister.UnRegisterProjectile(projectile);
                GameObject projectileGameObject = _gameObjectRegistry.GetProjectileGameObject(projectile);
                
                _gameObjectRegistry.UnRegisterGameObject(projectileGameObject);

                ITickable[] s = projectileGameObject.GetComponentsInChildren<ITickable>();
                foreach (ITickable ss in s)
                {
                    _battleTickService.RemoveTickable(ss);
                }

                GameObject.Destroy(projectileGameObject);
            }
        }
    }
}
