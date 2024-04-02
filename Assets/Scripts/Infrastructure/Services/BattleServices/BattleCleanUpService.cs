using Assets.Scripts.Infrastructure.Services.Registries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public class BattleCleanUpService : IBattleCleanUpServce
    {
        private readonly ISpaceShipsGameObjectRegistry _spaceShipsGameObjectRegistry;
        private readonly ISpaceShipRegistry _spaceShipRegistry;
        private readonly ICombatAIRegistry _combatAIRegistry;
        private readonly IBattleUIService _battleUIService;
        private readonly IBattleDataProvider _battleDataProvider;

        public BattleCleanUpService(ISpaceShipsGameObjectRegistry spaceShipsGameObjectRegistry, ISpaceShipRegistry spaceShipRegistry, ICombatAIRegistry combatAIRegistry, IBattleUIService battleUIService, IBattleDataProvider battleDataProvider)
        {
            _spaceShipsGameObjectRegistry = spaceShipsGameObjectRegistry;
            _spaceShipRegistry = spaceShipRegistry;
            _combatAIRegistry = combatAIRegistry;
            _battleUIService = battleUIService;
            _battleDataProvider = battleDataProvider;
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
