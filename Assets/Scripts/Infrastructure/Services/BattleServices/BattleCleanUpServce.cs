using Assets.Scripts.Infrastructure.Services.Registries;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public class BattleCleanUpServce : IBattleCleanUpServce
    {
        ISpaceShipsGameObjectRegistry _spaceShipsGameObjectRegistry;
        ISpaceShipRegistry _spaceShipRegistry;
        ICombatAiRegistry _combatAIRegistry;
        IBattleUIService _battleUIService;

        [Inject]
        public BattleCleanUpServce(ISpaceShipsGameObjectRegistry spaceShipsGameObjectRegistry, ISpaceShipRegistry spaceShipRegistry, ICombatAiRegistry combatAIRegistry, IBattleUIService battleUIService)
        {
            _spaceShipsGameObjectRegistry = spaceShipsGameObjectRegistry;
            _spaceShipRegistry = spaceShipRegistry;
            _combatAIRegistry = combatAIRegistry;
            _battleUIService = battleUIService;
        }

        public void CleanUpBattle(BattleData battleData)
        {
            GameObject.Destroy(_spaceShipsGameObjectRegistry.GetSpaceShipGameObject(battleData.PlayerSpaceShip));
            GameObject.Destroy(_spaceShipsGameObjectRegistry.GetSpaceShipGameObject(battleData.EnemySpaceShip));

            _spaceShipsGameObjectRegistry.UnregisterGameObject(_spaceShipsGameObjectRegistry.GetSpaceShipGameObject(battleData.PlayerSpaceShip));
            _spaceShipsGameObjectRegistry.UnregisterGameObject(_spaceShipsGameObjectRegistry.GetSpaceShipGameObject(battleData.EnemySpaceShip));

            _spaceShipRegistry.PlayerSpaceShip = null;
            _spaceShipRegistry.EnemySpaceShip = null;

            _combatAIRegistry.UnregisterAI(battleData.PlayerSpaceShip);
            _combatAIRegistry.UnregisterAI(battleData.EnemySpaceShip);
            _battleUIService.DestroyBattleUI();
        }
    }
}
