using Assets.Scripts.Entities.SpaceShips;
using Assets.Scripts.Infrastructure.Core.Services;
using Assets.Scripts.Infrastructure.Gameplay.Registries;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Gameplay.GameObjectDestroyers
{
    public class SpaceShipDestoyer : ISpaceShipDestroyer
    {
        private readonly IGameObjectRegistry _gameObjectRegistry;
        private readonly ISpaceShipAiRegistry _spaceShipAiRegistry;
        private readonly IGameplayTickService _gameplayTickService;

        [Inject]
        public SpaceShipDestoyer(IGameObjectRegistry gameObjectRegistry, ISpaceShipAiRegistry spaceShipAiRegistry, IGameplayTickService gameplayTickService)
        {
            _gameObjectRegistry = gameObjectRegistry;
            _spaceShipAiRegistry = spaceShipAiRegistry;
            _gameplayTickService = gameplayTickService;
        }

        public void Destroy(ISpaceShip spaceShip)
        {
            GameObject gameObject = _gameObjectRegistry.GetSpaceShipGameObject(spaceShip);

            ITickable[] tickables = gameObject.GetComponents<ITickable>();
            _gameplayTickService.RemoveTickable(tickables);

            _gameObjectRegistry.UnRegisterGameObject(gameObject);
            _spaceShipAiRegistry.UnRegisterAi(spaceShip);
            Object.Destroy(gameObject);
        }
    }
}
