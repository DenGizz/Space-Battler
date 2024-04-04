using Assets.Scripts.Battle;
using Assets.Scripts.Infrastructure.Services.Registries;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public class BattleCleanUpService : IBattleCleanUpServce
    {
        private readonly IGameObjectRegistry _gameObjectRegistry;
        private readonly ICombatAiRegistry _combatAIRegistry;
        private readonly IBattleUIService _battleUIService;
        private readonly IBattleProvider _battleProvider;

        [Inject]
        public BattleCleanUpService(IGameObjectRegistry gameObjectRegistry, ICombatAiRegistry combatAIRegistry, IBattleUIService battleUIService, IBattleProvider battleProvider)
        {
            _gameObjectRegistry = gameObjectRegistry;
            _combatAIRegistry = combatAIRegistry;
            _battleUIService = battleUIService;
            _battleProvider = battleProvider;
        }

        public void CleanUpBattle(Battle.Battle battle)
        {
            BattleData battleData = battle.BattleData;



            DestroyAndUnregisterGameObjects(battleData);


            _combatAIRegistry.UnregisterAI(battleData.PlayerSpaceShip);
            _combatAIRegistry.UnregisterAI(battleData.EnemySpaceShip);
            _battleUIService.DestroyBattleUI();

            _battleProvider.CurrentBattle = null;
        }

        private void DestroyAndUnregisterGameObjects(BattleData battleData)
        {
            foreach (var weapon in battleData.PlayerSpaceShip.Weapons)
            {
                GameObject weaponGameObject = _gameObjectRegistry.GetWeaponGameObject(weapon);
                GameObject.Destroy(weaponGameObject);
                _gameObjectRegistry.UnregisterGameObject(weaponGameObject);
            }

            foreach (var weapon in battleData.EnemySpaceShip.Weapons)
            {
                GameObject weaponGameObject = _gameObjectRegistry.GetWeaponGameObject(weapon);
                GameObject.Destroy(weaponGameObject);
                _gameObjectRegistry.UnregisterGameObject(weaponGameObject);
            }

            GameObject playerSpaceChipGameObject = _gameObjectRegistry.GetSpaceShipGameObject(battleData.PlayerSpaceShip);
            GameObject enemySpaceChipGameObject = _gameObjectRegistry.GetSpaceShipGameObject(battleData.EnemySpaceShip);

            GameObject.Destroy(playerSpaceChipGameObject);
            GameObject.Destroy(enemySpaceChipGameObject);

            _gameObjectRegistry.UnregisterGameObject(playerSpaceChipGameObject);
            _gameObjectRegistry.UnregisterGameObject(enemySpaceChipGameObject);
        }
    }
}
