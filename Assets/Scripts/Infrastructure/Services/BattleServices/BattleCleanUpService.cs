using Assets.Scripts.Battle;
using Assets.Scripts.Infrastructure.Services.Registries;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public class BattleCleanUpService : IBattleCleanUpServce
    {
        private readonly ISpaceShipsGameObjectRegistry _spaceShipsGameObjectRegistry;
        private readonly ICombatAiRegistry _combatAIRegistry;
        private readonly IBattleUIService _battleUIService;
        private readonly IBattleProvider _battleProvider;

        [Inject]
        public BattleCleanUpService(ISpaceShipsGameObjectRegistry spaceShipsGameObjectRegistry, ICombatAiRegistry combatAIRegistry, IBattleUIService battleUIService, IBattleProvider battleProvider)
        {
            _spaceShipsGameObjectRegistry = spaceShipsGameObjectRegistry;
            _combatAIRegistry = combatAIRegistry;
            _battleUIService = battleUIService;
            _battleProvider = battleProvider;
        }

        public void CleanUpBattle(Battle.Battle battle)
        {
            BattleData battleData = battle.BattleData;
            GameObject.Destroy(_spaceShipsGameObjectRegistry.GetSpaceShipGameObject(battleData.PlayerSpaceShip));
            GameObject.Destroy(_spaceShipsGameObjectRegistry.GetSpaceShipGameObject(battleData.EnemySpaceShip));

            _spaceShipsGameObjectRegistry.UnregisterGameObject(_spaceShipsGameObjectRegistry.GetSpaceShipGameObject(battleData.PlayerSpaceShip));
            _spaceShipsGameObjectRegistry.UnregisterGameObject(_spaceShipsGameObjectRegistry.GetSpaceShipGameObject(battleData.EnemySpaceShip));

            _combatAIRegistry.UnregisterAI(battleData.PlayerSpaceShip);
            _combatAIRegistry.UnregisterAI(battleData.EnemySpaceShip);
            _battleUIService.DestroyBattleUI();

            _battleProvider.CurrentBattle = null;
        }
    }
}
