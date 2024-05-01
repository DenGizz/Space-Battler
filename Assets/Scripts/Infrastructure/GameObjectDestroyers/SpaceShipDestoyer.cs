using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Services.CoreServices;
using Assets.Scripts.Infrastructure.Services.Registries;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Destroyers
{
    public class SpaceShipDestoyer : ISpaceShipDestroyer
    {
        private readonly IGameObjectRegistry _gameObjectRegistry;
        private readonly ICombatAiRegistry _combatAIRegistry;
        private readonly IBattleTickService _battleTickService;

        [Inject]
        public SpaceShipDestoyer(IGameObjectRegistry gameObjectRegistry, ICombatAiRegistry combatAIRegistry, IBattleTickService battleTickService)
        {
            _gameObjectRegistry = gameObjectRegistry;
            _combatAIRegistry = combatAIRegistry;
            _battleTickService = battleTickService;
        }

        public void Destroy(ISpaceShip spaceShip)
        {
            GameObject gameObject = _gameObjectRegistry.GetSpaceShipGameObject(spaceShip);

            _battleTickService.UnRegisterGameObjectTickables(gameObject);

            _gameObjectRegistry.UnRegisterGameObject(gameObject);
            _combatAIRegistry.UnRegisterAi(spaceShip);
            Object.Destroy(gameObject);
        }
    }
}
